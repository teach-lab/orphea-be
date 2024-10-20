using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ITokenRepo
{
    Task<TokenEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task SaveAsync(TokenEntity refresh, CancellationToken cancellationToken);

    Task DeleteAsync(Guid refreshId, CancellationToken cancellationToken);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}