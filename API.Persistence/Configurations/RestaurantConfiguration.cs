using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        // Table name and primary key
        builder.ToTable("Restaurants");
        builder.HasKey(r => r.Id);

        // Property configurations
        builder.Property(r => r.RestaurantName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(r => r.Address)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(r => r.RestaurantPhoneNumber)
            .HasMaxLength(15);

        builder.Property(r => r.CuisineType)
            .HasMaxLength(100);

        // Relationships
        builder.HasOne(r => r.Owner)
            .WithMany(ro => ro.Restaurants)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Reservations)
            .WithOne(res => res.Restaurant)
            .HasForeignKey(res => res.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Reviews)
            .WithOne(rv => rv.Restaurant)
            .HasForeignKey(rv => rv.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Menus) // One-to-Many Relationship
            .WithOne(m => m.Restaurant)
            .HasForeignKey(m => m.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}