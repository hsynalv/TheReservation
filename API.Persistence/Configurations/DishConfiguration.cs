using API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        // Table name and primary key
        builder.ToTable("Dishes");
        builder.HasKey(d => d.Id);

        // Property configurations
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(500);

        builder.Property(d => d.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(d => d.PhotoUrl)
            .HasMaxLength(255); // URL or path length limit

        // Relationships
        builder.HasOne(d => d.Menu)
            .WithMany(m => m.Dishes)
            .HasForeignKey(d => d.MenuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}