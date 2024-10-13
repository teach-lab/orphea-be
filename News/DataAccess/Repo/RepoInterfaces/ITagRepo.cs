using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface ITagRepo
    {
        Task<TagEntity> CreateAsync(TagEntity entity, CancellationToken cancellationToken);
        Task<TagEntity> GetAsync(Guid id, CancellationToken cancellationToken);        
        Task<TagEntity> UpdateAsync(TagEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
