using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IUom _uom;
        private readonly IMapper _mapper;
        public ProductController(IUom uom, IMapper mapper)
        {
            _uom = uom;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto product)
        {
            var productEntity = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductUrl = product.ProductUrl,
                ProductBrandId = product.ProductBrandId,
                ProductTypeId = product.ProductTypeId
            };

            await _uom.productRepository.CreateAsync(productEntity);
            await _uom.completedTask();

            return product;
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductDto product)
        {
            var productEntity = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductUrl = product.ProductUrl,
                ProductBrandId = product.ProductBrandId,
                ProductTypeId = product.ProductTypeId
            };

            await _uom.productRepository.UpdateAsync(id, productEntity);
            await _uom.completedTask();
            return product;
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteProduct(int id)
        {
            await _uom.productRepository.DeleteAsync(id);
            var deleteComplete = await _uom.completedTask();
            return deleteComplete;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var products = await _uom.productRepository.GetAll();
            var productToReturn = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(productToReturn);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProducts(int id)
        {
            var product = await _uom.productRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<Product,ProductDto>(product));
        }

        [HttpPost("brand")]
        public async Task<ActionResult<ProductBrand>> CreateBrand(ProductBrand brand)
        {
            var brands = await _uom.productBrandRepository.CreateAsync(brand);
            await _uom.completedTask();
            return brands;
        }
        [HttpPost("brands")]
        public async Task<ActionResult<IReadOnlyList< ProductBrand>>> CreateBrand(IReadOnlyList<ProductBrand> brand)
        {
            var brands = await _uom.productBrandRepository.CreateRangeAsync(brand);
            await _uom.completedTask();
            return Ok(brands);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _uom.productBrandRepository.GetAll();
            return Ok(brands);
        }

        [HttpPost("type")]
        public async Task<ActionResult<ProductType>> CreateProductType(ProductType productType)
        {
            var productTypeCreated = await _uom.productTypeRepository.CreateAsync(productType);
            await _uom.completedTask();
            return Ok(productTypeCreated);
        }
        [HttpPost("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> CreateProductType(IReadOnlyList<ProductType> productTypes)
        {
            var productTypesCreated = await _uom.productTypeRepository.CreateRangeAsync(productTypes);
            await _uom.completedTask();
            return Ok(productTypesCreated);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var types = await _uom.productTypeRepository.GetAll();
            return Ok(types);
        }
    }
}
