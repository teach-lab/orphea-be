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
        public PublisherEntity GetById(Guid id)
        {
            var result = _dbSet
                .Include(e => e.Articles)
                .ThenInclude(e => e.ArticleTags)
                .ThenInclude(e => e.Tag)
                .FirstOrDefault(e => e.Id == id);

            return result!;
        }

        public void Add(PublisherEntity entity)
        {
            var result = _dbSet.Add(entity);
        }

        public void Update(PublisherEntity entity)
        {
            var result = _dbSet.Update(entity);
        }

        public void Remove(PublisherEntity entity)
        {
            var result = _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
