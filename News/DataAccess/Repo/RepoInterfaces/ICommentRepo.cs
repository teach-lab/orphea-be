using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ICommentRepo
{
    Task<CommentEntity> GetCommentById(Guid id);

    Task<CommentEntity> CreateComment(CommentEntity comment);

    Task<CommentEntity> UpdateComment(CommentEntity comment);

    Task DeleteComment(Guid id);
}