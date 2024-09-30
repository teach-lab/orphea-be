using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities;

namespace News.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity>
{
    public PublisherConfiguration()
    {
    }

    public void Configure(EntityTypeBuilder<PublisherEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Articles)
            .WithOne(e => e.Publisher)
            .HasForeignKey(e => e.PublisherId);
    }
}