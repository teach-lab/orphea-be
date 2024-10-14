using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class PublisherRepo : IPublisherRepo
{   
    private readonly DbContext _context;
    private readonly DbSet<PublisherEntity> _dbSet;

    public PublisherRepo(DbContext context)
    {                        
        _dbSet = context.Set<PublisherEntity>();
        _context = context;
    }

    public async Task<PublisherEntity> CreateAsync(PublisherEntity entity, CancellationToken cancellationToken)
    {
        var result = (await _dbSet.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task<PublisherEntity> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return result;
    }

    

    public async Task<PublisherEntity> UpdateAsync(PublisherEntity entity, CancellationToken cancellationToken)
    {
        var result = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await GetAsync(id, cancellationToken);
        _dbSet.Remove(result);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
