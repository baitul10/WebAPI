using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUom
    {
        IProductRepository productRepository { get; }
        IProductBrandRepository productBrandRepository { get; }
        IProductTypeRepository productTypeRepository { get; }
        Task<int> completedTask();
    }
}
