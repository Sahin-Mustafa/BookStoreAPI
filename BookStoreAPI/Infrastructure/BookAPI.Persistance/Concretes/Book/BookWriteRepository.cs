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
        private IBookReadRepository bookReadRepository;
        public BookWriteRepository(BookAPIDbContext context, IBookReadRepository bookReadRepository) : base(context)
        {
            this.bookReadRepository = bookReadRepository;
        }
        public override async Task<bool> DeleteByIdAsync(int id)
        {
            Book book = await bookReadRepository.GetByIdAsync(id);
            if(book == null)
            {
                return false;
            }
            book.IsDelete = true;
            return true;
        }
    }
}
