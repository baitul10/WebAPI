using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product TEntity)
        {
            var result = await _context.Products.AddAsync(TEntity);
            return result.Entity;
        }

        public async Task<IReadOnlyList<Product>> CreateRangeAsync(IReadOnlyList<Product> TEntity)
        {
            await _context.Products.AddRangeAsync(TEntity);
            return TEntity;
        }

        public  Task DeleteAsync(int id)
        {
            var entityToDelete = GetByIdAsync(id);
             _context.Remove(entityToDelete);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<Product>> GetAll()
        {
            var products = await _context.Products
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductType)
                .ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(x=>x.ProductBrand)
                .Include(x=>x.ProductType)
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product TEntity)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.Name = TEntity.Name;
                product.Price = TEntity.Price;
                product.ProductUrl = TEntity.ProductUrl;
                product.ProductBrandId = TEntity.ProductBrandId;
                product.ProductTypeId = TEntity.ProductTypeId;
            }
            return product;
        }

    }
}
