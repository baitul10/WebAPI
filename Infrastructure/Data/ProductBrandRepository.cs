using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly StoreContext _context;
        public ProductBrandRepository(StoreContext context)
        {
            _context = context;
        }


        public async Task<ProductBrand> CreateAsync(ProductBrand TEntity)
        {
            var result = await _context.ProductBrands.AddAsync(TEntity);
            return result.Entity;
        }

        public async Task<IReadOnlyList<ProductBrand>> CreateRangeAsync(IReadOnlyList<ProductBrand> TEntity)
        {
           await _context.ProductBrands.AddRangeAsync(TEntity);
            return TEntity;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAll()
        {
            var brands = await _context.ProductBrands.ToListAsync();
            return brands;
        }

        public Task<ProductBrand> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductBrand> UpdateAsync(int id, ProductBrand TEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
