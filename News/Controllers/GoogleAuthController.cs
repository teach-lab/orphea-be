using Microsoft.AspNetCore.Mvc;
using News.Services;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("google-auth")]
public class GoogleAuthController : ControllerBase
{
    private readonly IGoogleAuthService _googleAuthService;

    public GoogleAuthController(IGoogleAuthService googleAuthService)
    {
        _googleAuthService = googleAuthService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] string googleAccess, CancellationToken cancellationToken)
    {
        var token = await _googleAuthService.LoginGoogleAsync(googleAccess, cancellationToken);

        return Ok(token);
    }
}