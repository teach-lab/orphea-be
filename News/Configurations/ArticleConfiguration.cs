using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities;

namespace News.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
{
    public void Configure(EntityTypeBuilder<ArticleEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.ArticleTags)
        .WithOne(e => e.Article)
        .HasForeignKey(e => e.ArticleId);

        builder.HasOne(e => e.Publisher)
            .WithMany(e => e.Articles)
            .HasForeignKey(e => e.PublisherId);       
    }
}