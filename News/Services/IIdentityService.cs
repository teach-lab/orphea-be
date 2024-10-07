using News.Entities.Models;

namespace News.Services;

public interface IIdentityService
{
    public Task<TokensPair> LoginAsync(LoginModel login, CancellationToken cancellationToken);

    public Task<TokensPair> RegisterAsync(UserCreateModel newUser, CancellationToken cancellationToken);

    public Task<bool> LogOutAsync(string refresh, CancellationToken cancellationToken);
}