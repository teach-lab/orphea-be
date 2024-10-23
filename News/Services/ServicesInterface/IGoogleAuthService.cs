using News.Entities.Models;

namespace News.Services.ServicesInterface;

public interface IGoogleAuthService
{
    public Task<TokensPair> LoginGoogleAsync(string googleAccess, CancellationToken cancellationToken);
}