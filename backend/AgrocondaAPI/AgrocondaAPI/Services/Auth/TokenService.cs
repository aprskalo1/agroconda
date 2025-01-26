using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AgrocondaAPI.Data;
using AgrocondaAPI.Exceptions;
using AgrocondaAPI.Models.Common;
using AgrocondaAPI.Models.Entities;
using AgrocondaAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AgrocondaAPI.Services.Auth;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    Task UpdateRefreshToken(Guid userId, string newRefreshToken);
    Task<TokensResponse> RefreshAccessToken(string refreshToken);
}

internal class TokenService(IConfiguration configuration, AgrocondaDbContext dbContext, IUserRepository userRepository) : ITokenService
{
    public string GenerateAccessToken(User user)
    {
        var jwtSettings = configuration.GetSection("JWT");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var userClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
            new(ClaimTypes.MobilePhone, user.FirstName ?? ""),
            new(ClaimTypes.MobilePhone, user.LastName ?? ""),
            new(ClaimTypes.MobilePhone, user.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ssZ"))
        };

        var accessToken = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: userClaims,
            expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpirationInMinutes"]!)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(accessToken);
    }

    public string GenerateRefreshToken()
    {
        const int tokenLengthInBytes = 64;
        var randomBytes = new byte[tokenLengthInBytes];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        var refreshToken = Convert.ToBase64String(randomBytes)
            .Replace("+", "-")
            .Replace("/", "_")
            .Replace("=", "");

        return refreshToken;
    }

    public async Task<TokensResponse> RefreshAccessToken(string refreshToken) //TODO: Include user check in this method
    {
        var validRefreshToken = await dbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken) ??
                                throw new TokenNotFoundException("Refresh token not found");

        var user = await userRepository.GetUserByRefreshTokenAsync(refreshToken);
        if (user == null)
            throw new UserNotFoundException("User with this refresh token not found");

        if (validRefreshToken.Expires < DateTime.Now)
            throw new UnauthorizedException("Refresh token expired");

        var accessToken = GenerateAccessToken(user);

        return new TokensResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task UpdateRefreshToken(Guid userId, string newRefreshToken)
    {
        var existingRefreshToken = await dbContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.UserId == userId);

        if (existingRefreshToken != null)
        {
            existingRefreshToken.Token = newRefreshToken;
            existingRefreshToken.Expires = DateTime.Now.AddDays(7);
        }
        else
        {
            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = newRefreshToken,
                Expires = DateTime.Now.AddDays(7)
            };

            await dbContext.RefreshTokens.AddAsync(refreshToken);
        }

        await dbContext.SaveChangesAsync();
    }
}