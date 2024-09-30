using Microsoft.EntityFrameworkCore;
using News.Entities;

namespace News.DataAccess.Repo;

public class ArticleRepo : IArticleRepo
{
    private readonly DbSet<ArticleEntity> _dbSet;
    private readonly DbContext _context;

        public ArticleRepo(DbContext context)
        {
            _dbSet = context.Set<ArticleEntity>();
            _context = context;
        }        

        public ArticleEntity Add(ArticleEntity entity)
        {
            var result = _dbSet.Add(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public ArticleEntity GetById(Guid id)
        {
            var result = _dbSet
                .Include(e => e.ArticleTags)
                .ThenInclude(at => at.Tag)
                .FirstOrDefault(e => e.Id == id);               

            return result!;
        }

        public void Update(ArticleEntity entity)
        {
            var result = _dbSet.Update(entity);
        }

        public void Remove(ArticleEntity entity)
        {
            var result = _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
