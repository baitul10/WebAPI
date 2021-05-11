using AutoMapper;
using Core.Entities;
using ProductAPI.DTOs;

namespace ProductAPI.Mapper
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.ProductUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
