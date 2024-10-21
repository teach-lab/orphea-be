using News.Entities;

namespace News.DataAccess.Repo;

public interface IArticleRepo
{
    Task<ArticleEntity> CreateAsync(ArticleEntity entity, CancellationToken cancellationToken);
    Task<ArticleEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ArticleEntity> UpdateAsync(ArticleEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}