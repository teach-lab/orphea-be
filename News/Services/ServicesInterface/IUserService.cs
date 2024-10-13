using Microsoft.AspNetCore.JsonPatch;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;

namespace News.Services.ServicesInterface;

public interface IUserService
{
    Task<UserResponseModel> CreateAsync(UserCreateModel user);
    Task<UserResponseModel> GetAsync(Guid id);
    Task<UserResponseModel> LoginAsync(LoginModel login);   
    Task<UserResponseModel> UpdateAsync(JsonPatchDocument<UserUpdateModel> user, string id);
    Task DeleteAsync(Guid id);
}