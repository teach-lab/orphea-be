using News.Entities;

namespace News.DataAccess.Repo.RepoInterfaces
{
    public interface IArticleTagRepo
    {
        public void AddRange(List<ArticleTagEntity> entity);
    }
}
