using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface IPublisherService
    {
        Task<PublisherModel> GetById(Guid id, CancellationToken cancellationToken);
        Task<PublisherCreateModel> Add(PublisherCreateModel model, CancellationToken cancellationToken);        
        Task<PublisherModel> Update(PublisherModel model, CancellationToken cancellationToken);
        Task Remove(Guid id, CancellationToken cancellationToken);
    }
}
