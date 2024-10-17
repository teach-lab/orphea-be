using News.Entities.Models;
using News.Entities.Models.ModelsCreate;

namespace News.Services.ServicesInterface;

public interface IIdentityService
{
    public Task<TokensPair> LoginAsync(LoginModel login, CancellationToken cancellationToken);
    public Task<TokensPair> RegisterAsync(UserCreateModel newUser, CancellationToken cancellationToken);
    public Task<bool> LogOutAsync(string refresh, CancellationToken cancellationToken);
}