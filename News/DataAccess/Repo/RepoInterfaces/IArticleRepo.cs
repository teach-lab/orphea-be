using News.Entities;

namespace News.DataAccess.Repo
{
    public interface IArticleRepo
    {
        Task<ArticleEntity> Add(ArticleEntity entity);
        Task<ArticleEntity> GetById(Guid id);
        Task<ArticleEntity> Update(ArticleEntity entity);
        Task Remove(Guid id);        
    }
}