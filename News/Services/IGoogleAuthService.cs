using News.Entities.Models;

namespace News.Services;

public interface IGoogleAuthService
{
    public Task<TokensPair> LoginGoogleAsync(string googleAccess, CancellationToken cancellationToken);
}