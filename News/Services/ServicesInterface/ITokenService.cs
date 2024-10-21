using News.Entities.Models;
using News.Entities.Models.ModelsRespones;

namespace News.Services.ServicesInterface;

public interface ITokenService
{
    public TokensPair GenerateTokensPairAsync(UserResponseModel user, CancellationToken cancellationToken);
    public Task<TokensPair> RefreshTokensPairAsync(string refresh, CancellationToken cancellationToken);
    Task SaveTokenAsync(string refresh, CancellationToken cancellationToken);
    Task DeleteTokenAsync(string refresh, CancellationToken cancellationToken);
}