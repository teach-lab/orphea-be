using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class TagRepo : ITagRepo
{
    private readonly DbSet<TagEntity> _dbSet;
    private readonly DbContext _context;

    public TagRepo(DbContext context)
    {
        _dbSet = context.Set<TagEntity>();
        _context = context;
    }

    public async Task<TagEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return entity;
    }

    public async Task<TagEntity> Add(TagEntity entity, CancellationToken cancellationToken)
    {
        var result = (await _dbSet.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task<TagEntity> Update(TagEntity entity, CancellationToken cancellationToken)
    {
        var result = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task Remove(Guid id, CancellationToken cancellationToken)
    {
        var result = await GetById(id, cancellationToken);
        _dbSet.Remove(result);
        await _context.SaveChangesAsync();
    }    
}
