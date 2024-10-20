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

    public async Task CreateAsync(
        PasswordEntity password,
        CancellationToken cancellationToken
        )
    {
        var entity = (await _dbSet.AddAsync(
            password,
            cancellationToken
            )).Entity;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PasswordEntity> GetByIdAsync(
        Guid? id,
        CancellationToken cancellationToken
        )
    {
        var entity = await _dbSet
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}