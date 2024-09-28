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

        public TagEntity GetById(Guid id)
        {
            var result = _dbSet
                .Include(e => e.ArticleTags)
                .ThenInclude(f => f.Article)
                .FirstOrDefault(e => e.Id == id);

            return result!;
        }

        public void Add(TagEntity entity)
        {
            var result = _dbSet.Add(entity);
        }

        public void Update(TagEntity entity)
        {
            var result = _dbSet.Update(entity);
        }

        public void Remove(TagEntity entity)
        {
            var result = _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
