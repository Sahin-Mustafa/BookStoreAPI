using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Persistance.Context
{
    public class BookAPIDbContext : DbContext
    {
        public BookAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
