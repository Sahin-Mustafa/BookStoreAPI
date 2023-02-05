using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace BookAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //find all handler, request and response and add IoC
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddHttpClient();
        }

    }
}
