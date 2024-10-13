using Google.Apis.Auth;
using Google.Apis.Util;
using Microsoft.Extensions.Options;
using News.Entities.Models;
using News.Infrastructure;

namespace News.Services;

public class GoogleAuthService : IGoogleAuthService
{
    private readonly GoogleAuthOptions _options;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    private readonly HttpClient _httpClient;
    private readonly IClock _clock;

    public GoogleAuthService(IOptions<GoogleAuthOptions> options, ITokenService tokenService, IUserService userService, HttpClient httpClient)
    {
        _options = options.Value;
        _tokenService = tokenService;
        _userService = userService;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://oauth2.googleapis.com/");
        _clock = SystemClock.Default;
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