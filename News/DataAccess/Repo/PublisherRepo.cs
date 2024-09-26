using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo
{
    public class PublisherRepo : IPublisherRepo
    {
        private readonly DbSet<PublisherEntity> _dbSet;
        private readonly DbContext _context;

        public PublisherRepo(DbContext context)
        {
            _dbSet = context.Set<PublisherEntity>();
            _context = context;
        }
    }
}
