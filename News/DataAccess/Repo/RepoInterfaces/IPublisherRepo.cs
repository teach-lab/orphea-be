using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IPublisherRepo
{
    Task<PublisherEntity> CreateAsync(PublisherEntity entity, CancellationToken cancellationToken);
    Task<PublisherEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);        
    Task<PublisherEntity> UpdateAsync(PublisherEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
