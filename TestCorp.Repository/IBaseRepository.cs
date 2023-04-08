using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCorp.Repository
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByAsync(T item);
        Task<T?> CreateAsync(T item);
        Task<T?> UpdateAsync(T item);
        Task<T?> DeleteAsync(int id);
    }
}
