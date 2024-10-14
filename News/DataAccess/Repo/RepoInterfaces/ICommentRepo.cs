using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ICommentRepo
{
    Task<CommentEntity> CreateAsync(CommentEntity comment, CancellationToken cancellationToken);
    Task<CommentEntity> GetAsync(Guid id, CancellationToken cancellationToken);    
    Task<CommentEntity> UpdateAsync(CommentEntity comment, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}