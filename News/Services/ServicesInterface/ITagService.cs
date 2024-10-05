using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface ITagService
    {
        Task<TagModel> GetById(Guid id);
        Task<TagModel> Add(TagModel model);
        Task<TagModel> Update(TagModel model);
        Task Remove(Guid id);        
    }
}
