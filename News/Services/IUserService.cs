using Microsoft.AspNetCore.JsonPatch;
using News.Entities;
using News.Entities.Models;

namespace News.Services;

public interface IUserService
{
    Task<UserResponseModel> GetUserById(Guid id);

    Task<UserResponseModel> Login(LoginModel login);

    Task<UserResponseModel> CreateUser(UserCreateModel user);

    Task<UserResponseModel> UpdateUser(JsonPatchDocument<UserUpdateModel> user, string id);

    Task DeleteUser(Guid id);
}