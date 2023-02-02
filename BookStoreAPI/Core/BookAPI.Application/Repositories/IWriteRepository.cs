using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> data);
        bool Delete(T model);
        Task<bool> DeleteByIdAsync(int id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
