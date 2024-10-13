using News.Entities;

namespace News.DataAccess.Repo;

public interface IArticleRepo
{
    Task<ArticleEntity> Add(ArticleEntity entity, CancellationToken cancellationToken);
    Task<ArticleEntity> GetById(Guid id, CancellationToken cancellationToken);
    Task<ArticleEntity> Update(ArticleEntity entity, CancellationToken cancellationToken);
    Task Remove(Guid id, CancellationToken cancellationToken);        
}