namespace StorageApi.Dtos
{
    public record CreateProductDto(string Name, int Price, int Count, string Category, string Shelf, string Description);
}
