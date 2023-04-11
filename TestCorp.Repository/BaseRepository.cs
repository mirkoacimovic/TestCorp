using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCorp.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public Task<T?> CreateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T?> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
