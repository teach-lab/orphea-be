using Microsoft.AspNetCore.Mvc;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("identities")]
public class IdentitiesController : ControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public IdentitiesController(IIdentityService identityService, ITokenService tokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login, CancellationToken cancellationToken)
    {
        if (login is null)
        {
            return BadRequest("Login data cannot be null.");
        }

        var token = await _identityService.LoginAsync(login, cancellationToken);
        if (token is null)
        {
            return Unauthorized("Invalid credentials.");
        }

        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateModel user, CancellationToken cancellationToken)
    {
        if (user is null)
        {
            return BadRequest("User data cannot be null.");
        }

        var token = await _identityService.RegisterAsync(user, cancellationToken);
        if (token is null)
        {
            return BadRequest("Registration failed.");
        }

        return Ok(token);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] string refresh, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(refresh))
        {
            return BadRequest("Refresh token cannot be null or empty.");
        }

        var result = await _identityService.LogOutAsync(refresh, cancellationToken);
        if (!result)
        {
            return BadRequest("Logout failed.");
        }

        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] string refresh, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(refresh))
        {
            return BadRequest("Refresh token cannot be null or empty.");
        }

        var token = await _tokenService.RefreshTokensPairAsync(refresh, cancellationToken);
        if (token is null)
        {
            return Unauthorized("Invalid or expired refresh token.");
        }

        return Ok(token);
    }
}