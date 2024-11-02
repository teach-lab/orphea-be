using Microsoft.EntityFrameworkCore;
using News.DataAccess.Repo.GenericRepositories;
using News.Entities;

namespace News.DataAccess.Repo;

public class ArticleRepo : GenericRepo<ArticleEntity>, IArticleRepo
{
    public ArticleRepo(DbContext context)
        : base(context)
    {
    }
}