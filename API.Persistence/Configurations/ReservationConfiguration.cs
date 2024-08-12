using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistence.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        // Table name and primary key
        builder.ToTable("Reservations");
        builder.HasKey(res => res.Id);

        // Property configurations
        builder.Property(res => res.ReservationTime)
            .IsRequired();

        builder.Property(res => res.GuestCount)
            .IsRequired();

        // Relationships
        builder.HasOne(res => res.Customer)
            .WithMany(u => u.Reservations)
            .HasForeignKey(res => res.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(res => res.Restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(res => res.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}