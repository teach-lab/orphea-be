using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class ArticleTagRepo : IArticleTagRepo
{
    private readonly DbContext _context;
    private readonly DbSet<ArticleTagEntity> _dbSet;

    public ArticleTagRepo(DbContext context)
    {        
        _dbSet = context.Set<ArticleTagEntity>();
        _context = context;        
    }
    public async Task AddRangeAsync(List<ArticleTagEntity> entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entity, cancellationToken);   
        await _context.SaveChangesAsync(cancellationToken);        
    }    
}
