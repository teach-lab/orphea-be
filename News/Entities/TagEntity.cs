namespace News.Entities;

public class TagEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }    
    public List<ArticleTagEntity>? ArticleTags { get; set;}
}