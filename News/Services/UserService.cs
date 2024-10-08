﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;
using News.Infrastructure;

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

    public async Task<UserResponseModel> GetUserById(Guid id)
    {
        var entity = await _repo.GetUserById(id);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }

    public async Task<UserResponseModel> UpdateUser(JsonPatchDocument<UserUpdateModel> user, string id)
    {
        var entity = await _repo.GetUserById(Guid.Parse(id));
        var userToUpdate = new UserUpdateModel
        {
            Username = entity.Username,
            Email = entity.Email,
            Login = entity.Login
        };

        user.ApplyTo(userToUpdate);

        entity.Username = userToUpdate.Username;
        entity.Email = userToUpdate.Email;
        entity.Login = userToUpdate.Login;

        await _repo.UpdateUser(entity);

        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);
        return result;
    }

    public async Task<UserResponseModel> CreateUser(UserCreateModel user)
    {
        var salt = _passwordEncryptionHelper.GenerateSalt(user.Password);
        var hashedPassword = _passwordEncryptionHelper.HashPassword(user.Password, salt);
        var passwordEntity = new PasswordEntity
        {
            Id = Guid.NewGuid(),
            Salt = salt,
            Hash = hashedPassword
        };

        await _passwordRepo.CreatePassword(passwordEntity);

        var UserEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Username = user.Username,
            Email = user.Email,
            Login = user.Login,
            PasswordId = passwordEntity.Id
        };

        var addedEntity = await _repo.CreateUser(UserEntity);
        var result = _mapper.Map<UserEntity, UserResponseModel>(addedEntity);

        return result;
    }

    public async Task DeleteUser(Guid id)
    {
        await _repo.DeleteUser(id);
    }
}