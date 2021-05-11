using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly StoreContext _context;
        public ProductTypeRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<ProductType> CreateAsync(ProductType TEntity)
        {
            var result = await _context.ProductTypes.AddAsync(TEntity);
            return result.Entity;
        }

        public async Task<IReadOnlyList<ProductType>> CreateRangeAsync(IReadOnlyList<ProductType> TEntity)
        {
            await _context.ProductTypes.AddRangeAsync(TEntity);
            return TEntity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductType>> GetAll()
        {
            var types = await _context.ProductTypes.ToListAsync();
            return types;
        }

        public Task<ProductType> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductType> UpdateAsync(int id, ProductType TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
