namespace News.Entities.Models;

public class PublisherModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int? TrustScore { get; set; }
}