namespace News.Entities.Models;

public class TagModel
{
    public string Name { get; set; }

    public List<ArticleModel>? Articles { get; set; }
    
}
