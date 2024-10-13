using Google.Apis.Auth;
using News.Entities.Models;

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

        var user = await _userService.GetUserByEmail(payload.Email);

        if (user is null)
        {
            var newUser = new UserCreateModel
            {
                FirstName = payload.GivenName,
                Email = payload.Email,
                Login = payload.Email,
            };

            var createdUser = await _userService.CreateUserViaSso(newUser);

            var newToken = _tokenService.GenerateTokensPair(createdUser, cancellationToken);

            await _tokenService.SaveToken(newToken.Refresh, cancellationToken);

            return newToken;
        }

        var token = _tokenService.GenerateTokensPair(user, cancellationToken);

        await _tokenService.SaveToken(token.Refresh, cancellationToken);

        return token;
    }
}