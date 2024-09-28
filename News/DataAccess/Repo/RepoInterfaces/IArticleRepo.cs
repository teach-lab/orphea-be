using News.Entities;

namespace News.DataAccess.Repo
{
    public interface IArticleRepo
    {
        ArticleEntity Add(ArticleEntity entity);
        ArticleEntity GetById(Guid id);
        void Update(ArticleEntity entity);
        void Remove(ArticleEntity entity);
        void SaveChanges();
    }
}