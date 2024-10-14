using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IUserRepo
{
    Task<UserEntity> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<UserEntity> GetLoginAsync(string login, CancellationToken cancellationToken);
    Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken);
    Task<UserEntity> UpdateAsync(UserEntity user, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}