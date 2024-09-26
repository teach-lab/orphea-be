using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo
{
    public class ArticleTagRepo : IArticleTagRepo
    {
        private readonly DbSet<ArticleTagEntity> _dbSet;
        private readonly DbContext _context;

        public ArticleTagRepo(DbContext context)
        {
            _dbSet = context.Set<ArticleTagEntity>();
            _context = context;
        }
    }
}
