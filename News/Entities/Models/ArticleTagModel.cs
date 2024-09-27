namespace News.Entities.Models;

public class ArticleTagModel
{
    public Guid ArticleId { get; set; }
    public ArticleEntity? Article { get; set; }


    public Guid TagId { get; set; }
    public TagEntity? Tag { get; set; }
}
