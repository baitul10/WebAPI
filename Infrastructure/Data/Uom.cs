using Core.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Uom : IUom
    {

        public StoreContext _context { get; }
        public Uom(StoreContext context)
        {
            _context = context;
        }

        public IProductRepository productRepository => new ProductRepository(_context);

        public IProductBrandRepository productBrandRepository => new  ProductBrandRepository(_context);

        public IProductTypeRepository productTypeRepository => new ProductTypeRepository(_context);

        public async Task<int> completedTask()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
