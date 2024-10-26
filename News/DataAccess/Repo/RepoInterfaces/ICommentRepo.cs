using News.DataAccess.Repo.GenericRepositories;
using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface ICommentRepo : IGenericRepo<CommentEntity>
{
}