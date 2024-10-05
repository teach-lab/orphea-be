using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface IArticleService
    {
        Task<ArticleModel> Add(ArticleModel model);
        Task<ArticleModel> GetById(Guid id);
        Task<ArticleModel> Update(ArticleModel model);
        Task Remove(Guid id);
    }
}
