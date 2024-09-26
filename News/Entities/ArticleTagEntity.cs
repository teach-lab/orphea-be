namespace News.Entities
{
    public class ArticleTagEntity
    {
        public Guid ArticleId { get; set; }    
        public ArticleEntity? Article { get; set; }


        public Guid TagId { get; set; }   
        public TagEntity? Tag { get; set; }

    }
}
