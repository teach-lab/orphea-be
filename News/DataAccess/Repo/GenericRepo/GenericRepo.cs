using Microsoft.EntityFrameworkCore;

namespace News.DataAccess.Repo.GenericRepositories;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepo(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task<T> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}