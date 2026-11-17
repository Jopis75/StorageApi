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
                    Name = "Product 1",
                    Price = 10,
                    Category = "Category 1",
                    Shelf = "Shelf 1",
                    Count = 100,
                    Description = "Description 1"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 20,
                    Category = "Category 2",
                    Shelf = "Shelf 2",
                    Count = 200,
                    Description = "Description 2"
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Price = 30,
                    Category = "Category 3",
                    Shelf = "Shelf 3",
                    Count = 300,
                    Description = "Description 3"
                }
            );
        }
    }
}
