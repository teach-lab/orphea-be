using News.Entities.Models;
using News.Entities.Models.ModelsCreate;
using News.Entities.Models.ModelsRespones;
using News.Entities.Models.ModelsUpdate;

namespace News.Services.ServicesInterface;

public interface ICommentService
{
    Task<CommentModel> GetCommentById(Guid id);

    Task<CommentResponseModel> CreateComment(CommentCreateModel user);

    Task<CommentResponseModel> UpdateComment(CommentUpdateModel user, string id);

    Task DeleteComment(Guid id);
}