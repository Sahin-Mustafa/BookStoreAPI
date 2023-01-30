using BookAPI.Application.Abstraction.Token;
using BookAPI.Infrastructure.Service.Token;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }

    }
}
