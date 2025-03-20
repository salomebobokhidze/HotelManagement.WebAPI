using HotelManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Hotel entity (if needed)
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(h => h.Id); // Primary key
                entity.Property(h => h.Name).IsRequired().HasMaxLength(100);
                entity.Property(h => h.Rating).IsRequired();
                entity.Property(h => h.Country).IsRequired().HasMaxLength(100);
                entity.Property(h => h.City).IsRequired().HasMaxLength(100);
                entity.Property(h => h.Address).IsRequired().HasMaxLength(255);
            });
        }
    }
}