using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class TagRepo : ITagRepo
{
    private readonly DbContext _context;

    public TagRepo(DbContext context)
    {
        _context = context;
    }

    public TagEntity GetById(Guid id)
    {
        return _context.Set<TagEntity>().Find(id);        
    }

    public void Add(TagEntity entity)
    {
        _context.Add(entity);
    }

    public void Update(TagEntity entity)
    {
        _context.Update(entity);
    }

    public void Remove(TagEntity entity)
    {
        _context.Remove(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }    
}
