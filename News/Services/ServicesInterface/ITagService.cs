using News.Entities.Models;
using News.Entities.Models.ModelsCreate;

namespace News.Services.ServicesInterface
{
    public interface ITagService
    {
        Task<TagCreateModel> CreateAsync(TagCreateModel model, CancellationToken cancellationToken);

        Task<TagModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<TagModel> UpdateAsync(TagModel model, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}