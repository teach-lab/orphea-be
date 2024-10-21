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

    public async Task<CommentEntity> CreateAsync(
        CommentEntity comment,
        CancellationToken cancellationToken
        )
    {
        var result = (await _dbSet.AddAsync(comment, cancellationToken)).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return result;
    }
    public async Task<CommentEntity> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken
        )
    {
        var result = await _dbSet
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return result;
    }

    public async Task<CommentEntity> UpdateAsync(
        CommentEntity comment,
        CancellationToken cancellationToken
        )
    {
        var entity = _dbSet.Update(comment).Entity;
        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}