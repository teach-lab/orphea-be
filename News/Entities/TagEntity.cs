namespace News.Entities;

public class TagEntity : BaseEntity
{
    public string Name { get; set; }

    public List<ArticleTagEntity>? ArticleTags { get; set; }
}