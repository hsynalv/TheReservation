using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using API.Domain.Entity;
using API.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Context
{
    public class APIDbContext : IdentityDbContext<AppUser,AppRole, string>
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Assembly'deki tüm IEntityTypeConfiguration implementasyonlarını uygula
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<RestaurantOwner>()
                .ToTable("RestaurantOwners");

            modelBuilder.Entity<User>()
                .ToTable("Users");
        }
    }
}
