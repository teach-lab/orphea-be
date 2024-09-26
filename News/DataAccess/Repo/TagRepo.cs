using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo
{
    public class TagRepo : ITagRepo
    {
        private readonly DbSet<TagEntity> _dbSet;
        private readonly DbContext _context;

        public TagRepo(DbContext context)
        {
            _dbSet = context.Set<TagEntity>();
            _context = context;
        }
    }
}
