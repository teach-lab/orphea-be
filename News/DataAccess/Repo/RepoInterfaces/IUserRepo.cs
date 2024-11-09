using News.DataAccess.Repo.GenericRepositories;
using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IUserRepo : IGenericRepo<UserEntity>
{
    Task<UserEntity> GetLoginAsync(string login, CancellationToken cancellationToken);

    Task<UserEntity> GetByEmailAsync(string email, CancellationToken cancellationToken);
}