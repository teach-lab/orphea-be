using Microsoft.EntityFrameworkCore;
using News.Entities;

namespace News.DataAccess.Repo;

public class ArticleRepo : IArticleRepo
{
    private readonly DbContext _context;
    private readonly DbSet<ArticleEntity> _dbSet;

    public ArticleRepo(DbContext context)
    {        
        _dbSet = context.Set<ArticleEntity>(); 
        _context = context;
    }        

    public async Task<ArticleEntity> CreateAsync(ArticleEntity entity, CancellationToken cancellationToken)
    {
        var result = (await _dbSet.AddAsync(entity, cancellationToken)).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }

    public async Task<ArticleEntity> GetAsync(Guid id, CancellationToken cancellationToken)
    {      
        var result = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return result;
    }

    public async Task<ArticleEntity> UpdateAsync(ArticleEntity entity, CancellationToken cancellationToken)
    {
        var result = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
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

