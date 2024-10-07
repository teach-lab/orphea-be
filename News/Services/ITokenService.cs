using News.Entities.Models;

namespace News.Services;

public interface ITokenService
{
    public TokensPair GenerateTokensPair(UserResponseModel user, CancellationToken cancellationToken);

    public Task<TokensPair> RefreshTokensPair(string refresh, CancellationToken cancellationToken);

    Task SaveToken(string refresh, CancellationToken cancellationToken);

    Task DeleteToken(string refresh, CancellationToken cancellationToken);
}