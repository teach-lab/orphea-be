using News.Entities.Models;
using News.Entities.Models.ModelsCreate;

namespace News.Services.ServicesInterface
{
    public interface IPublisherService
    {
        Task<PublisherCreateModel> CreateAsync(PublisherCreateModel model, CancellationToken cancellationToken);
        Task<PublisherModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);               
        Task<PublisherModel> UpdateAsync(PublisherModel model, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
