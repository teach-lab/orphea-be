using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface IArticleTagRepo
    {
        public Task AddRange(List<ArticleTagEntity> entity, CancellationToken cancellationToken);
    }
}
