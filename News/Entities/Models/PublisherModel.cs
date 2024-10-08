﻿namespace News.Entities.Models;

public class PublisherModel
{
    public string Name { get; set; }
    public int TrustScore { get; set; }

    public List<ArticleEntity> Articles { get; set; }
}
