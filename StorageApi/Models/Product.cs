namespace StorageApi.Models
{
    public class Product
    {
        int Id { get; set; }
        string Name { get; set; } = string.Empty;
        int Price { get; set; }
        string Category { get; set; } = string.Empty;
        string Shelf { get; set; } = string.Empty;
        int Count { get; set; }
        string Description { get; set; } = string.Empty;
    }
}
