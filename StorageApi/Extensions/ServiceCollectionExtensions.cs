using Microsoft.EntityFrameworkCore;
using StorageApi.DbContexts;

namespace StorageApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Action<DbContextOptionsBuilder> dbContextOptionsBuilder = dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("StorageConnectionString"));
            serviceCollection.AddDbContext<StorageContext>(dbContextOptionsBuilder);
            return serviceCollection;
        }
    }
}
