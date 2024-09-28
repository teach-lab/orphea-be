using News.Entities.Models;

namespace News.Services;

public interface ICommentService
{
    Task<CommentModel> GetCommentById(Guid id);

    Task<CommentResponseModel> CreateComment(CommentCreateModel user);

    Task DeleteComment(Guid id);
}