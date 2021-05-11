using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T TEntity);
        Task<IReadOnlyList<T>> CreateRangeAsync(IReadOnlyList<T> TEntity);
        Task<T> UpdateAsync(int id, T TEntity);
        Task DeleteAsync(int id);

    }
}



