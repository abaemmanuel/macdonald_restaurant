using AutoMapper;
using MacDonald.Services.ProductAPI.Models;
using MacDonald.Services.ProductAPI.Models.DTO;

namespace MacDonald.Services.ProductAPI.Settings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
