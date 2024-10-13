using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ITagRepo
{
    Task<TagEntity> GetById(Guid id, CancellationToken cancellationToken);
    Task<TagEntity> Add(TagEntity entity, CancellationToken cancellationToken);
    Task<TagEntity> Update(TagEntity entity, CancellationToken cancellationToken);
    Task Remove(Guid id, CancellationToken cancellationToken);
}
