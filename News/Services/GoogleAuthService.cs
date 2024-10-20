using Google.Apis.Auth;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Services.ServicesInterface;

namespace News.Services;

public class GoogleAuthService : IGoogleAuthService
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public GoogleAuthService(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    public async Task<TokensPair> LoginGoogleAsync(string googleAccess, CancellationToken cancellationToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(googleAccess);

        var user = await _userService.GetByEmailAsync(payload.Email, cancellationToken);

        if (user is null)
        {
            var newUser = new UserCreateModel
            {
                FirstName = payload.GivenName,
                Email = payload.Email,
                Login = payload.Email,
            };

            var createdUser = await _userService.CreateViaSsoAsync(newUser, cancellationToken);

            var newToken = _tokenService.GenerateTokensPairAsync(createdUser, cancellationToken);

            await _tokenService.SaveTokenAsync(newToken.Refresh, cancellationToken);

            return newToken;
        }

        var token = _tokenService.GenerateTokensPairAsync(user, cancellationToken);

        await _tokenService.SaveTokenAsync(token.Refresh, cancellationToken);

        return token;
    }
}