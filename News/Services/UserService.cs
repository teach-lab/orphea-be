using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;
using News.Infrastructure;
using News.Services.ServicesInterface;

namespace News.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _repo;
    private readonly IPasswordRepo _passwordRepo;
    private readonly IPasswordEncryptionHelper _passwordEncryptionHelper;
    private readonly IMapper _mapper;

    public UserService(
        IUserRepo repo,
        IPasswordRepo passwordRepo,
        IPasswordEncryptionHelper passwordEncryptionHelper,
        IMapper mapper
        )
    {
        _repo = repo;
        _passwordRepo = passwordRepo;
        _passwordEncryptionHelper = passwordEncryptionHelper;
        _mapper = mapper;
    }

    public async Task<UserResponseModel> CreateAsync(
        UserCreateModel user,
        CancellationToken cancellationToken
        )
    {
        var salt = _passwordEncryptionHelper.GenerateSalt(user.Password);
        var hashedPassword = _passwordEncryptionHelper.HashPassword(user.Password, salt);
        var passwordEntity = new PasswordEntity
        {
            Id = Guid.NewGuid(),
            Salt = salt,
            Hash = hashedPassword
        };

        await _passwordRepo.CreateAsync(passwordEntity, cancellationToken);

        var UserEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            Email = user.Email,
            Login = user.Login,
            PasswordId = passwordEntity.Id
        };

        var createdUser = await _repo.CreateAsync(UserEntity, cancellationToken);
        var result = _mapper.Map<UserEntity, UserResponseModel>(createdUser);

        return result;
    }

    public async Task<UserResponseModel> CreateViaSsoAsync(UserCreateModel user, CancellationToken cancellationToken)
    {
        var UserEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            FirstName = user.FirstName,
            Email = user.Email,
            Login = user.Login
        };

        var createdUser = await _repo.CreateAsync(UserEntity, cancellationToken);

        var result = _mapper.Map<UserEntity, UserResponseModel>(createdUser);

        return result;
    }

    public async Task<UserResponseModel> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _repo.GetByIdAsync(id, cancellationToken);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }

    public async Task<UserResponseModel> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetByEmailAsync(email, cancellationToken);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }

    public async Task<UserResponseModel> LoginAsync(
        LoginModel login,
        CancellationToken cancellationToken
        )
    {
        var user = await _repo.GetLoginAsync(login.Login, cancellationToken);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var password = await _passwordRepo.GetByIdAsync(user.PasswordId, cancellationToken);
        var hashedPassword = _passwordEncryptionHelper.VerifyPassword(
            login.Password,
            password.Hash,
            password.Salt
            );

        if (!hashedPassword)
        {
            throw new Exception("Invalid password");
        }

        var result = _mapper.Map<UserEntity, UserResponseModel>(user);

        return result;
    }

    public async Task<UserResponseModel> UpdateAsync(
        JsonPatchDocument<UserUpdateModel> user,
        string id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _repo.GetByIdAsync(Guid.Parse(id), cancellationToken);
        var userToUpdate = new UserUpdateModel
        {
            FirstName = entity.FirstName,
            Email = entity.Email,
            Login = entity.Login
        };

        user.ApplyTo(userToUpdate);

        entity.FirstName = userToUpdate.FirstName;
        entity.Email = userToUpdate.Email;
        entity.Login = userToUpdate.Login;

        await _repo.UpdateAsync(entity, cancellationToken);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _repo.DeleteAsync(id, cancellationToken);
    }
}