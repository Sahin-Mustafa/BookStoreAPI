using BookAPI.Application.Repositories;
using BookAPI.Domain.Entites;
using BookAPI.Persistance.Context;
using BookAPI.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Persistance.Concretes
{
    public class BookWriteRepository : WriteRepository<Book>,IBookWriteRepository
    {
        public BookWriteRepository(BookAPIDbContext context) : base(context)
        {
        }
    }
}
