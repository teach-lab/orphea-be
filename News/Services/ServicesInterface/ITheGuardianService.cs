using News.Entities.ModelsSourceNewsApi;

namespace News.Services.ServicesInterface;

public interface ITheGuardianService
{
    Task<TheGuardianModel> GetAllArticlesAsync();

    Task<TheGuardianArticleModel> GetSignleAsync(string id);
}