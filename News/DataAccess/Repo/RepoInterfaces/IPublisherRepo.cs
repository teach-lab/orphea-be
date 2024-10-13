using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IPublisherRepo
{
    Task<PublisherEntity> GetById(Guid id, CancellationToken cancellationToken);
    Task<PublisherEntity> Add(PublisherEntity entity, CancellationToken cancellationToken);
    Task<PublisherEntity> Update(PublisherEntity entity, CancellationToken cancellationToken);
    Task Remove(Guid id, CancellationToken cancellationToken);        
}
