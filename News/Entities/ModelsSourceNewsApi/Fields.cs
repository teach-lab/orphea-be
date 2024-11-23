namespace News.Entities.ModelsSourceNewsApi
{
    public class Fields : TheGuardianModel
    {
        public string? Headline { get; set; }
        public string? Standfirst { get; set; }
        public string? TrailText { get; set; }
        public string? Byline { get; set; }
        public string? Main { get; set; }
        public string? Body { get; set; }
        public int? Wordcount { get; set; }
        public DateTime? FirstPublicationDate { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? LiveBloggingNow { get; set; }
        public string? Publication { get; set; }
        public string? Thumbnail { get; set; }
        public bool? LegallySensitive { get; set; }
        public string? Lang { get; set; }
        public bool? IsLive { get; set; }
        public string? BodyText { get; set; }
        public int? CharCount { get; set; }
        public string? BylineHtml { get; set; }
        public bool? ShowTableOfContents { get; set; }
    }
}