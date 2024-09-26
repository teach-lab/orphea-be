using Microsoft.EntityFrameworkCore;
using News.Entities;

namespace News.DataAccess.Repo
{
    public class ArticleRepo : IArticleRepo
    {
        private readonly DbSet<ArticleEntity> _dbSet;
        private readonly DbContext _context;

        public ArticleRepo(DbContext context)
        {
            _dbSet = context.Set<ArticleEntity>();
            _context = context;
        }
    }
}
