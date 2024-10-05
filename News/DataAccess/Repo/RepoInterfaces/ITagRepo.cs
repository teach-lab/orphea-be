using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface ITagRepo
    {
        Task<TagEntity> GetById(Guid id);
        Task<TagEntity> Add(TagEntity entity);
        Task<TagEntity> Update(TagEntity entity);
        Task Remove(Guid id);
    }
}
