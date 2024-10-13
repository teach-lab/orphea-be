using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ICommentRepo
{
    Task<CommentEntity> CreateAsync(CommentEntity comment);
    Task<CommentEntity> GetAsync(Guid id);    
    Task<CommentEntity> UpdateAsync(CommentEntity comment);
    Task DeleteAsync(Guid id);
}