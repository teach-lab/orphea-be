using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface ITagRepo
    {
        TagEntity GetById(Guid id);
        void Add(TagEntity entity);
        void Update(TagEntity entity);
        void Remove(TagEntity entity);
        void SaveChanges();
    }
}
