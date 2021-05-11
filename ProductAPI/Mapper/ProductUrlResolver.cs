using AutoMapper;
using Core.Entities;
using ProductAPI.DTOs;
using Microsoft.Extensions.Configuration;

namespace ProductAPI.Mapper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ProductUrl))
            return _config["ApiUrl"] + source.ProductUrl;

            return null;
        }
    }
}
