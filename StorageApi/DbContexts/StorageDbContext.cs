using Microsoft.EntityFrameworkCore;
using StorageApi.Configurations;
using StorageApi.Models;

namespace StorageApi.DbContexts
{
    public class StorageDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageDbContext(DbContextOptions<StorageDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Product>()
               .ToTable("Product");
            modelBuilder
                .Entity<Product>()
                .HasKey(product => product.Id);

            // Configurations.
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
