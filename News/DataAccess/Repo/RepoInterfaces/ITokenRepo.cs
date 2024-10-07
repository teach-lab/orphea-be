using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ITokenRepo
{
    Task<TokenEntity> GetRefreshById(Guid id, CancellationToken cancellationToken);

    Task SaveToken(TokenEntity refresh, CancellationToken cancellationToken);

    Task DeleteToken(Guid refreshId, CancellationToken cancellationToken);
}