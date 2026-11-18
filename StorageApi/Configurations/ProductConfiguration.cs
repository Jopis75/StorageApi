using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageApi.Models;

namespace StorageApi.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "PRIME GeForce RTX™ 5080",
                    Price = 19700,
                    Category = "GPU",
                    Shelf = "Shelf 1",
                    Count = 10,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Product
                {
                    Id = 2,
                    Name = "PlayStation®5 Pro",
                    Price = 11900,
                    Category = "Console",
                    Shelf = "Shelf 2",
                    Count = 25,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                },
                new Product
                {
                    Id = 3,
                    Name = "ASUS ROG Delta II",
                    Price = 2989,
                    Category = "Gaming Headset",
                    Shelf = "Shelf 3",
                    Count = 100,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                }
            );
        }
    }
}
