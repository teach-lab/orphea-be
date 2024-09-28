using AutoMapper;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;
using News.Entities.Models;

namespace News.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _repo;
    private readonly IMapper _mapper;

    public UserService(IUserRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<UserResponseModel> GetUserById(Guid id)
    {
        var entity = await _repo.GetUserById(id);
        var result = _mapper.Map<UserEntity, UserResponseModel>(entity);

        return result;
    }

    public async Task<UserResponseModel> CreateUser(UserCreateModel user)
    {
        var entity = _mapper.Map<UserCreateModel, UserEntity>(user);
        var addedEntity = await _repo.CreateUser(entity);
        var result = _mapper.Map<UserEntity, UserResponseModel>(addedEntity);

        return result;
    }

    public async Task DeleteUser(Guid id)
    {
        await _repo.DeleteUser(id);
    }
}