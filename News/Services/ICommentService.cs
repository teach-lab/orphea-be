using News.Entities.Models;

namespace News.Services;

public interface ICommentService
{
    Task<CommentModel> GetCommentById(Guid id);

    Task<CommentResponseModel> CreateComment(CommentCreateModel user);

    Task<CommentResponseModel> UpdateComment(CommentUpdateModel user, string id);

    Task DeleteComment(Guid id);
}