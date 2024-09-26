namespace News.Entities
{
    public class PublisherEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TrustScore { get; set; }

        public List<ArticleEntity> Articles { get; set; }
    }
}
