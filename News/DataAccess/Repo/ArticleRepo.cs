using Microsoft.EntityFrameworkCore;
using News.Entities;

namespace News.DataAccess.Repo;

public class ArticleRepo : IArticleRepo
{
    private readonly DbContext _context;

    public ArticleRepo(DbContext context)
    {        
        _context = context;
    }        

    public ArticleEntity Add(ArticleEntity entity)
    {
        var result = _context.Add(entity);
        _context.SaveChanges();

        return result.Entity;
    }

    public ArticleEntity GetById(Guid id)
    {      
        return _context.Set<ArticleEntity>().Find(id);
    }

    public void Update(ArticleEntity entity)
    {
        var result = _context.Update(entity);
    }

    public void Remove(ArticleEntity entity)
    {
        var result = _context.Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}

