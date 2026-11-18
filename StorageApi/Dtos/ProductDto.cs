namespace StorageApi.Dtos
{
    public record ProductDto(int Id, string Name, int Price, int Count, string Category, string Shelf, string Description);
}
