using AutoMapper;
using StorageApi.Dtos;
using StorageApi.Models;

namespace StorageApi.Profiles
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
