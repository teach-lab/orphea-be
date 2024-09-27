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
}