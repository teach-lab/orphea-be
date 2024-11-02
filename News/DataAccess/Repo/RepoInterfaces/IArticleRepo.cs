using News.DataAccess.Repo.GenericRepositories;
using News.Entities;

namespace News.DataAccess.Repo;

public interface IArticleRepo : IGenericRepo<ArticleEntity>
{
}