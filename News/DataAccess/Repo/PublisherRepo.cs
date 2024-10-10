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
        public async Task<PublisherEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        return result;
    }

        public async Task<PublisherEntity> Add(PublisherEntity entity, CancellationToken cancellationToken)
        {
            var result = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task<PublisherEntity> Update(PublisherEntity entity, CancellationToken cancellationToken)
    {
        var result = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync(cancellationToken);
        return result;
    }

        public async Task Remove(Guid id, CancellationToken cancellationToken)
    {
        var result = await GetById(id, cancellationToken);
        _dbSet.Remove(result);
        await _context.SaveChangesAsync(cancellationToken);
    }        
}
