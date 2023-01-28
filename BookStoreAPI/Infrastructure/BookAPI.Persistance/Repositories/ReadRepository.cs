using BookAPI.Application.Repositories;
using BookAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly BookAPIDbContext _context;

        public ReadRepository(BookAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table =>_context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public T GetById(int id) => Table.Find(id);

        public T GetSingle(Expression<Func<T, bool>> method) => Table.FirstOrDefault(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)=>Table.Where(method);
        
    }
}
