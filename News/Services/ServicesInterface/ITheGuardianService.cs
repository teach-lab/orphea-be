using News.Entities.ModelsSourceNewsApi;

namespace News.Services.ServicesInterface;

public interface ITheGuardianService
{
    Task<TheGuardianModel> GetAllAsync(CancellationToken cancellationToken);

    Task<TheGuardianArticleModel> GetAsync(string id, CancellationToken cancellationToken);
}