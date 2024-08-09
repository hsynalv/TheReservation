using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class RestaurantOwnerConfiguration : IEntityTypeConfiguration<RestaurantOwner>
{
    public void Configure(EntityTypeBuilder<RestaurantOwner> builder)
    {

        // Property configurations
        builder.Property(ro => ro.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(ro => ro.PhoneNumber)
            .HasMaxLength(15);

        // Relationships
        builder.HasMany(ro => ro.Restaurants)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}