using News.Entities.Models;

namespace News.Services;

public interface IUserService
{
    Task<UserResponseModel> GetUserById(Guid id);

    Task<UserResponseModel> CreateUser(UserCreateModel user);

    Task DeleteUser(Guid id);

}
