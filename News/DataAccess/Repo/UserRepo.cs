using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class UserRepo : IUserRepo
{
    private readonly DbSet<UserEntity> _dbSet;
    private readonly DbContext _context;

    public UserRepo(DbContext context)
    {
        _dbSet = context.Set<UserEntity>();
        _context = context;
    }

    public async Task<UserEntity> GetUserById(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        return entity;
    }

    public async Task<UserEntity> CreateUser(UserEntity user)
    {
        var entity = (await _dbSet.AddAsync(user)).Entity;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<UserEntity> UpdateUser(UserEntity user)
    {
        var entity = _dbSet.Update(user).Entity;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteUser(Guid id)
    {
        var entity = await GetUserById(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}