using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface IArticleService
    {
        ArticleModel Add(ArticleModel model);
        ArticleModel GetById(Guid id);
        void Update(ArticleModel model);
        void Remove(ArticleModel model);
    }
}
