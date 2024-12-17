using News.Entities.ModelsSourceNewsApi;

namespace News.Services.ServicesInterface;

public interface IXPublisherService
{
    Task<TheGuardianModel> GetAllAsync(CancellationToken cancellationToken);

    Task<TheGuardianArticleModel> GetAsync(string id, CancellationToken cancellationToken);
}