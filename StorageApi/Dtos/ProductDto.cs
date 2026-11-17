using System.ComponentModel.DataAnnotations;

namespace StorageApi.Dtos
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Shelf { get; set; } = string.Empty;

        [Required]
        public int Count { get; set; }

        public string Description { get; set; } = string.Empty;

        public int InventoryValue => Price * Count;
    }
}
