using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.model;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfigTesting : Profile
    {
        public MappingConfigTesting()
        {
            CreateMap<ProductVO, Product>();
            CreateMap<Product, ProductVO>();
        }
    }
}
