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
    public class CustomerWriteRepository : WriteRepository<Customer>,ICustomerWriteRepository
    {
        public CustomerWriteRepository(BookAPIDbContext context) : base(context)
        {
        }
    }
}
