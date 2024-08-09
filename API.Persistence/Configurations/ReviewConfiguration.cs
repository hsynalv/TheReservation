using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        // Table name and primary key
        builder.ToTable("Reviews");
        builder.HasKey(rv => rv.Id);

        // Property configurations
        builder.Property(rv => rv.Rating)
            .IsRequired();

        builder.Property(rv => rv.Comment)
            .HasMaxLength(1000);

        // Relationships
        builder.HasOne(rv => rv.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(rv => rv.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rv => rv.Restaurant)
            .WithMany(r => r.Reviews)
            .HasForeignKey(rv => rv.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}