using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Entities;

namespace News.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Password)
            .WithOne()
            .HasForeignKey<UserEntity>(e => e.PasswordId);

        builder.HasMany(e => e.Comments)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);        

        builder.HasMany(e => e.RefreshTokens)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
    }
}