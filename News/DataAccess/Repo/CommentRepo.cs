using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.DataAccess.Repo.RepoInterfaces;
using News.Entities;

namespace News.DataAccess.Repo;

public class CommentRepo : GenericRepo<CommentEntity>, ICommentRepo
{
    public CommentRepo(DbContext context)
        : base(context)
    {
    }
}