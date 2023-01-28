using BookAPI.Application.Repositories;
using BookAPI.Persistance.Concretes;
using BookAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<BookAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
        }
    }
}
