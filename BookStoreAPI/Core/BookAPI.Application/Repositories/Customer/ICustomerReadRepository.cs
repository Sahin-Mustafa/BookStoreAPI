using BookAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Application.Repositories
{
    public interface ICustomerReadRepository : IReadRepository<Customer>
    {
    }
}
