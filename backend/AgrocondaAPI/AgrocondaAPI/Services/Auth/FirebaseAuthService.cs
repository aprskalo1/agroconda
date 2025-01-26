using AgrocondaAPI.Exceptions;
using AgrocondaAPI.Models.Entities;
using AgrocondaAPI.Repositories;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2.Responses;

namespace AgrocondaAPI.Services.Auth;

public interface IFirebaseAuthService
{
    Task<TokenResponse> GenerateAccessTokenWithFirebase(string firebaseToken);
}

internal class FirebaseAuthService(FirebaseAuth firebaseAuth, IUserRepository userRepository, ITokenService tokenService) : IFirebaseAuthService
{
    public async Task<TokenResponse> GenerateAccessTokenWithFirebase(string firebaseToken)
    {
        var decodedToken = await firebaseAuth.VerifyIdTokenAsync(firebaseToken);
        var userId = decodedToken.Claims["user_id"].ToString();
        var userEmail = decodedToken.Claims["email"].ToString();
        var username = decodedToken.Claims["name"].ToString();

        if (userId == null || userEmail == null || username == null)
        {
            throw new UserNotFoundException("Oops! User was not found. Please try again.");
        }

        var user = await userRepository.GetUserByFirebaseUidAsync(userId);
        if (user == null)
        {
            var newUser = new User
            {
                FirebaseUid = userId,
                Email = userEmail,
                Username = username
            };
            user = await userRepository.CreateUserAsync(newUser);
            await userRepository.SaveChangesAsync();
        }

        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = tokenService.GenerateRefreshToken();
        await tokenService.UpdateRefreshToken(user.Id, refreshToken);

        return new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}