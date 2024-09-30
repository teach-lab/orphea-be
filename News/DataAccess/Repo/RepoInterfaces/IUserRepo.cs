using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IUserRepo
{
    Task<UserEntity> GetUserById(Guid id);

    Task<UserEntity> CreateUser(UserEntity user);

    Task<UserEntity> UpdateUser(UserEntity user);

    Task DeleteUser(Guid id);
}