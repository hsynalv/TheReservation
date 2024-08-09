using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        // Table name and primary key
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);

        // Property configurations
        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasOne(m => m.Restaurant)
            .WithOne(r => r.Menu)
            .HasForeignKey<Menu>(m => m.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Dishes)
            .WithOne(d => d.Menu)
            .HasForeignKey(d => d.MenuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}