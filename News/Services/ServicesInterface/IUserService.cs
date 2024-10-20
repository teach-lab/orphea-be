using Microsoft.AspNetCore.JsonPatch;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;

namespace News.Services.ServicesInterface;

public interface IUserService
{
    Task<UserResponseModel> CreateAsync(UserCreateModel user, CancellationToken cancellationToken);

    Task<UserResponseModel> CreateViaSsoAsync(UserCreateModel user, CancellationToken cancellationToken);

    Task<UserResponseModel> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<UserResponseModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<UserResponseModel> LoginAsync(LoginModel login, CancellationToken cancellationToken);

    Task<UserResponseModel> UpdateAsync(JsonPatchDocument<UserUpdateModel> user, string id, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}