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

    public async Task<ArticleEntity> Add(ArticleEntity entity)
    {
        var result = (await _dbSet.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<ArticleEntity> GetById(Guid id)
    {      
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        return entity;
    }

    public async Task<ArticleEntity> Update(ArticleEntity entity)
    {
        var result = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task Remove(Guid id)
    {
        var entity = await GetById(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}

