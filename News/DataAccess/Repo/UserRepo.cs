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

    public async Task<UserEntity> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task<UserEntity> GetLoginAsync(string login, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Login == login, cancellationToken);

        return entity;
    }

    public async Task<UserEntity> CreateAsync(UserEntity user, CancellationToken cancellationToken)
    {
        var entity = (await _dbSet.AddAsync(user)).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<UserEntity> UpdateAsync(UserEntity user, CancellationToken cancellationToken)
    {
        var entity = _dbSet.Update(user).Entity;
        await _context.SaveChangesAsync( cancellationToken);

        return entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(id, cancellationToken);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}