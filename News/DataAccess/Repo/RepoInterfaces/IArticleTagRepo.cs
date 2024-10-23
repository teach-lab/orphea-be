using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces;

public interface IArticleTagRepo
{
    public Task AddRangeAsync(List<ArticleTagEntity> entity, CancellationToken cancellationToken);
}