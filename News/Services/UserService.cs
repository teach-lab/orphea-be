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

    public UserService(IUserRepo repo, IPasswordRepo passwordRepo, IPasswordEncryptionHelper passwordEncryptionHelper, IMapper mapper)
    {
        _repo = repo;
        _passwordRepo = passwordRepo;
        _passwordEncryptionHelper = passwordEncryptionHelper;
        _mapper = mapper;
    }

    public async Task<UserResponseModel> CreateAsync(UserCreateModel user)
    {
        var salt = _passwordEncryptionHelper.GenerateSalt(user.Password);
        var hashedPassword = _passwordEncryptionHelper.HashPassword(user.Password, salt);
        var passwordEntity = new PasswordEntity
        {
            Id = Guid.NewGuid(),
            Salt = salt,
            Hash = hashedPassword
        };

        await _passwordRepo.CreateAsync(passwordEntity);

        var UserEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            FullName = user.FullName,
            Email = user.Email,
            Login = user.Login,
            PasswordId = passwordEntity.Id
        };

        var createdUser = await _repo.CreateAsync(UserEntity);
        var result = _mapper.Map<UserEntity, UserResponseModel>(createdUser);

        return result;
    }

    public async Task<UserResponseModel> GetAsync(Guid id)
    {
        var entity = await _repo.GetAsync(id);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }

    public async Task<UserResponseModel> LoginAsync(LoginModel login)
    {
        var user = await _repo.GetLoginAsync(login.Login);
        if (user is null)
        {
            throw new Exception("User not found");
        }

        var password = await _passwordRepo.GetAsync(user.PasswordId);
        var hashedPassword = _passwordEncryptionHelper.VerifyPassword(login.Password, password.Hash, password.Salt);

        if (!hashedPassword)
        {
            throw new Exception("Invalid password");
        }

        var result = _mapper.Map<UserEntity, UserResponseModel>(user);

        return result;
    }

    public async Task<UserResponseModel> UpdateAsync(JsonPatchDocument<UserUpdateModel> user, string id)
    {
        var entity = await _repo.GetAsync(Guid.Parse(id));
        var userToUpdate = new UserUpdateModel
        {
            FullName = entity.FullName,
            Email = entity.Email,
            Login = entity.Login
        };

        user.ApplyTo(userToUpdate);

        entity.FullName = userToUpdate.FullName;
        entity.Email = userToUpdate.Email;
        entity.Login = userToUpdate.Login;

        await _repo.UpdateAsync(entity);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }        

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}