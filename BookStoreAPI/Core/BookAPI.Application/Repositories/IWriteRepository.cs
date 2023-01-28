using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        bool Add(T model);
        bool AddRange(List<T> data);
        bool Delete(T model);
        bool DeleteById(int id);
        bool Update(T model);
        int Save();
    }
}
