using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class PasswordRepo : IPasswordRepo
{
    private readonly DbSet<PasswordEntity> _dbSet;
    private readonly DbContext _context;

    public PasswordRepo(DbContext context)
    {
        _dbSet = context.Set<PasswordEntity>();
        _context = context;
    }

    public async Task CreateAsync(PasswordEntity password)
    {
        var entity = (await _dbSet.AddAsync(password)).Entity;
        await _context.SaveChangesAsync();
    }

    public async Task<PasswordEntity> GetAsync(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        return entity;
    }
}