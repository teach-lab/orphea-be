using News.Entities.Models;

namespace News.Services.ServicesInterface
{
    public interface ITagService
    {
        Task<TagModel> GetById(Guid id, CancellationToken cancellationToken);
        Task<TagModel> Add(TagModel model, CancellationToken cancellationToken);
        Task<TagModel> Update(TagModel model, CancellationToken cancellationToken);
        Task Remove(Guid id, CancellationToken cancellationToken);        
    }
}
