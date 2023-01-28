using BookAPI.Application.Repositories;
using BookAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly BookAPIDbContext _context;

        public WriteRepository(BookAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public bool Add(T model)
        {
            EntityEntry<T> entityEntry = Table.Add(model);
            return entityEntry.State == EntityState.Added;
        }

        public bool AddRange(List<T> data)
        {
            Table.AddRange(data);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool DeleteById(int id)
        {
            EntityEntry<T> entityEntry = Table.Remove(Table.Find(id));
            return entityEntry.State == EntityState.Deleted;
        }

        

        public int Save() => _context.SaveChanges();

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;

        }
    }
}
