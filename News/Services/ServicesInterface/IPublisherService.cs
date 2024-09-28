using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface IPublisherService
    {
        PublisherModel Add(PublisherModel model);
        PublisherModel GetById(Guid id);
        void Update(PublisherModel model);
        void Remove(PublisherModel model);
    }
}
