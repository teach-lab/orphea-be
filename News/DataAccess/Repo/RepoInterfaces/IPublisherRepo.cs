using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface IPublisherRepo
    {
        Task<PublisherEntity> GetById(Guid id);
        Task<PublisherEntity> Add(PublisherEntity entity);
        Task<PublisherEntity> Update(PublisherEntity entity);
        Task Remove(Guid id);        
    }
}
