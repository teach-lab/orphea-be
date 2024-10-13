using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;

namespace News.Services.ServicesInterface;

public interface ICommentService
{
    Task<CommentResponseModel> CreateAsync(CommentCreateModel user);
    Task<CommentModel> GetAsync(Guid id);
    Task<CommentResponseModel> UpdateAsync(CommentUpdateModel user, string id);
    Task DeleteAsync(Guid id);
}