using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ICommentRepo
{
    Task<CommentEntity> GetCommentById(Guid id);

    Task<CommentEntity> CreateComment(CommentEntity user);

    Task<CommentEntity> UpdateComment(CommentEntity user);

    Task DeleteComment(Guid id);
}