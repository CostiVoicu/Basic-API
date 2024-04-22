using Microsoft.EntityFrameworkCore;
using Project.Database.Entities;

namespace Project.Database.Context
{
    public class PetShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasKey(s => s.Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Store)           
                .WithMany(s => s.Products)      
                .HasForeignKey(p => p.StoreId) 
                .OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PetShop;Username=postgres;Password=1q2w3e");
            }
        }
    }
}
