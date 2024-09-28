using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface IPublisherRepo
    {
        PublisherEntity GetById(Guid id);
        void Add(PublisherEntity entity);
        void Update(PublisherEntity entity);
        void Remove(PublisherEntity entity);
        void SaveChanges();
    }
}
