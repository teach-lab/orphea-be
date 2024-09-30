using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class PublisherRepo : IPublisherRepo
{   
    private readonly DbContext _context;

        public PublisherRepo(DbContext context)
        {            
            _context = context;
        }
        public PublisherEntity GetById(Guid id)
        {
            return _context.Set<PublisherEntity>().Find(id);
        }

        public void Add(PublisherEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(PublisherEntity entity)
        {
            _context.Update(entity);
        }

        public void Remove(PublisherEntity entity)
        {
            _context.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }    
}
