using Microsoft.AspNetCore.JsonPatch;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;

namespace News.Services.ServicesInterface;

public interface IUserService
{
    Task<UserResponseModel> GetUserById(Guid id);

    Task<UserResponseModel> Login(LoginModel login);

    Task<UserResponseModel> CreateUser(UserCreateModel user);

    Task<UserResponseModel> UpdateUser(JsonPatchDocument<UserUpdateModel> user, string id);

    Task DeleteUser(Guid id);
}