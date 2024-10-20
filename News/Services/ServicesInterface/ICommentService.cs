using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;

namespace News.Services.ServicesInterface;

public interface ICommentService
{
    Task<CommentResponseModel> CreateAsync(CommentCreateModel user, CancellationToken cancellationToken);

    Task<CommentModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<CommentResponseModel> UpdateAsync(CommentUpdateModel user, string id, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}