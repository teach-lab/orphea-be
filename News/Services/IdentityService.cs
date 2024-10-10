﻿using News.Entities.Models;
using News.Infrastructure;

namespace News.Services;

public class IdentityService : IIdentityService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly IPasswordEncryptionHelper _passwordEncryptionHelper;

    public IdentityService(IUserService userService, ITokenService tokenService, IPasswordEncryptionHelper passwordEncryptionHelper)
    {
        _userService = userService;
        _tokenService = tokenService;
        _passwordEncryptionHelper = passwordEncryptionHelper;
    }

    public async Task<TokensPair> LoginAsync(LoginModel login, CancellationToken cancellationToken)
    {
        var user = await _userService.Login(login);

        var token = _tokenService.GenerateTokensPair(user, cancellationToken);

        await _tokenService.SaveToken(token.Refresh, cancellationToken);

        return token;
    }

    public async Task<TokensPair> RegisterAsync(UserCreateModel newUser, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateUser(newUser);

        var token = _tokenService.GenerateTokensPair(user, cancellationToken);

        await _tokenService.SaveToken(token.Refresh, cancellationToken);

        return token;
    }

    public async Task<bool> LogOutAsync(string refresh, CancellationToken cancellation)
    {
        await _tokenService.DeleteToken(refresh, cancellation);

        return true;
    }
}