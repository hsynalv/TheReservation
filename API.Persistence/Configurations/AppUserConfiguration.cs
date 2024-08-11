using API.Domain.Entities;
using API.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // Table name and primary key configuration
        builder.ToTable("AppUsers");
        builder.HasKey(u => u.Id);

        // General properties configuration
        builder.Property(u => u.CreatedDate)
            .IsRequired();

        // Relationships
        builder.HasOne(u => u.Customer)
            .WithOne(c => c.AppUser)
            .HasForeignKey<Customer>(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.RestaurantOwner)
            .WithOne(ro => ro.AppUser)
            .HasForeignKey<RestaurantOwner>(ro => ro.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}