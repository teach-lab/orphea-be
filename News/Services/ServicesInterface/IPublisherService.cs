using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface IPublisherService
    {
        Task<PublisherModel> GetById(Guid id);
        Task<PublisherModel> Add(PublisherModel model);        
        Task<PublisherModel> Update(PublisherModel model);
        Task Remove(Guid id);
    }
}
