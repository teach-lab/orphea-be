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

    public async Task<CommentEntity> GetCommentById(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        return entity;
    }

    public async Task<CommentEntity> CreateComment(CommentEntity comment)
    {
        //Include
        var entity = (await _dbSet.AddAsync(comment)).Entity;
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<CommentEntity> UpdateComment(CommentEntity comment)
    {
        var entity = _dbSet.Update(comment).Entity;

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteComment(Guid id)
    {
        var entity = await GetCommentById(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}