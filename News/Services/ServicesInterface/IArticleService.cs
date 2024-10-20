using News.Entities.Models;
using News.Entities.Models.ModelsCreate;

namespace News.Services.ServicesInterface
{
    public interface IArticleService
    {
        Task<ArticleCreateModel> CreateAsync(ArticleCreateModel model, CancellationToken cancellationToken);

        Task<ArticleModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<ArticleModel> UpdateAsync(ArticleModel model, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}