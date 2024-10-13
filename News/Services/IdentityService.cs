using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Infrastructure;
using News.Services.ServicesInterface;

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
        var user = await _userService.LoginAsync(login);
        var token = _tokenService.GenerateTokensPairAsync(user, cancellationToken);
        await _tokenService.SaveTokenAsync(token.Refresh, cancellationToken);

        return token;
    }

    public async Task<TokensPair> RegisterAsync(UserCreateModel newUser, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateAsync(newUser);
        var token = _tokenService.GenerateTokensPairAsync(user, cancellationToken);
        await _tokenService.SaveTokenAsync(token.Refresh, cancellationToken);
        return token;
    }

    public async Task<bool> LogOutAsync(string refresh, CancellationToken cancellation)
    {
        await _tokenService.DeleteTokenAsync(refresh, cancellation);

        return true;
    }
}