using AgrocondaAPI.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AgrocondaAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(ITokenService tokenService, IFirebaseAuthService firebaseAuthService) : ControllerBase
{
    [HttpPost("firebase")]
    public async Task<IActionResult> FirebaseLogin(string firebaseToken)
    {
        var tokens = await firebaseAuthService.GenerateAccessTokenWithFirebase(firebaseToken);
        return Ok(tokens);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var tokens = await tokenService.RefreshAccessToken(refreshToken);
        return Ok(tokens);
    }
}