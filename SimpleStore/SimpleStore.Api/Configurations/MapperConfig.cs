using AutoMapper;
using SimpleStore.Api.Data;
using SimpleStore.Api.Models;

namespace SimpleStore.Api.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
