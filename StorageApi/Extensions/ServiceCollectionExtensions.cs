using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StorageApi.DbContexts;
using StorageApi.Dtos;
using StorageApi.Profiles;
using StorageApi.Validators;

namespace StorageApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection serviceCollection)
        {
            // services.AddAutoMapper(cfg => { }, typeof(ProfileTypeFromAssembly1), typeof(ProfileTypeFromAssembly2) /*, ...*/);
            serviceCollection.AddAutoMapper(cfg => { }, typeof(StorageProfile));
            return serviceCollection;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Action<DbContextOptionsBuilder> dbContextOptionsBuilder = dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("StorageDbContextConnectionString"));
            serviceCollection.AddDbContext<StorageDbContext>(dbContextOptionsBuilder);
            return serviceCollection;
        }

        public static IServiceCollection AddValidators(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();
            serviceCollection.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();
            serviceCollection.AddScoped<IValidator<UpdateProductDto>, UpdateProductDtoValidator>();
            return serviceCollection;
        }
    }
}
