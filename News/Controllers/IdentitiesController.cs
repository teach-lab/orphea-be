﻿using Microsoft.AspNetCore.Mvc;
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
        var token = await _identityService.LoginAsync(login, cancellationToken);

        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateModel user, CancellationToken cancellationToken)
    {
        var token = await _identityService.RegisterAsync(user, cancellationToken);

        return Ok(token);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] string refresh, CancellationToken cancellationToken)
    {
        var result = await _identityService.LogOutAsync(refresh, cancellationToken);

        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] string refresh, CancellationToken cancellationToken)
    {
        var token = await _tokenService.RefreshTokensPair(refresh, cancellationToken);

        return Ok(token);
    }
}