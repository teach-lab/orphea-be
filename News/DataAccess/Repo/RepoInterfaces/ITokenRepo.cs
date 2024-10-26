using News.DataAccess.Repo.GenericRepositories;
using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ITokenRepo : IGenericRepo<TokenEntity>
{
    Task SaveAsync(TokenEntity refresh, CancellationToken cancellationToken);
}