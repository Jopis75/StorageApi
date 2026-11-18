namespace StorageApi.Dtos
{
    public class StatsDto
    {
        //  Totalt antal produkter.
        public int TotalProductCount { get; set; }

        //Totalt lagervärde.
        public int TotalStoragePrice { get; set; }

        // Snittpris.
        public double AveragePrice { get; set; }
    }
}
