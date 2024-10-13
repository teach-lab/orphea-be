using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IUserRepo
{
    Task<UserEntity> GetAsync(Guid id);

    Task<UserEntity> GetLoginAsync(string login);

    Task<UserEntity> CreateAsync(UserEntity user);

    Task<UserEntity> UpdateAsync(UserEntity user);

    Task DeleteAsync(Guid id);
}