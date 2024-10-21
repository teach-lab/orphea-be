using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities;

namespace News.Configurations;

public class ArticleTagConfiguration : IEntityTypeConfiguration<ArticleTagEntity>
{
    public void Configure(EntityTypeBuilder<ArticleTagEntity> builder)
    {
        builder.HasKey(e => new { e.ArticleId, e.TagId });

        builder.HasOne(e => e.Article)
            .WithMany(e => e.ArticleTags)
            .HasForeignKey(e => e.ArticleId);

        builder.HasOne(e => e.Tag)
            .WithMany(e => e.ArticleTags)
            .HasForeignKey(e => e.TagId);
    }
}