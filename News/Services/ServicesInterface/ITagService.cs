using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface ITagService
    {
        TagModel Add(TagModel model);
        TagModel GetById(Guid id);
        void Update(TagModel model);
        void Remove(Guid id);        
    }
}
