using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class CommentRepo : ICommentRepo
{
    private readonly DbSet<CommentEntity> _dbSet;
    private readonly DbContext _context;

    public CommentRepo(DbContext context)
    {
        _dbSet = context.Set<CommentEntity>();
        _context = context;
    }   

    public async Task<CommentEntity> CreateAsync(CommentEntity comment)
    {
        var result = (await _dbSet.AddAsync(comment)).Entity;
        await _context.SaveChangesAsync();

        return result;
    }
    public async Task<CommentEntity> GetAsync(Guid id)
    {
        var result = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        return result;
    }

    public async Task<CommentEntity> UpdateAsync(CommentEntity comment)
    {
        var entity = _dbSet.Update(comment).Entity;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}