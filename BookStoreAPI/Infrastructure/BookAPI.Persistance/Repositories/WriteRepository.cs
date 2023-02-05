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
       
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> data)
        {
            await Table.AddRangeAsync(data);
            return true;
        }

        public bool Delete(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            T entityEntry = await Table.FindAsync(id);
            return Delete(entityEntry);
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;

        }
        async Task<int> IWriteRepository<T>.SaveAsync()=>await _context.SaveChangesAsync();
    }
}
