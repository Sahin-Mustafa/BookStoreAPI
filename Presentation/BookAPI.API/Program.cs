using BookAPI.Application.Validators.Customer;
using BookAPI.Persistance;
using FluentValidation.AspNetCore;

namespace BookAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(opt=>
                                     opt.AddDefaultPolicy(policy=>
                                                          policy.AllowAnyHeader()
                                                          .AllowAnyMethod()
                                                          .AllowAnyOrigin()));
            // Add services to the container.
            builder.Services.AddPersistanceServices();
            builder.Services.AddControllers().AddFluentValidation(conf=>conf.RegisterValidatorsFromAssemblyContaining<CreateCustomer>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}