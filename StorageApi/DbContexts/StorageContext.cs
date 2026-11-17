using Microsoft.EntityFrameworkCore;
using StorageApi.Models;

namespace StorageApi.DbContexts
{
    public class StorageContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public StorageContext(DbContextOptions<StorageContext> dbContextOptions)
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
        }
    }
}
