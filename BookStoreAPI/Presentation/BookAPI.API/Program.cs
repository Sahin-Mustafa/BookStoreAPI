using BookAPI.Application;
using BookAPI.Persistance;
using BookAPI.Application.Validators.Customer;
using FluentValidation.AspNetCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BookAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(opt =>
                                     opt.AddDefaultPolicy(policy =>
                                                          policy.AllowAnyHeader()
                                                          .AllowAnyMethod()
                                                          .AllowAnyOrigin()));
            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistanceServices();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddControllers().AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<CreateCustomer>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("ADMÝN",opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        ValidateAudience = false, //hagni originlerin ulaþabileceði
                        ValidateIssuer= false,//token kim daðýtýyor
                        ValidateLifetime= true,//token geçerlilik süresi
                        ValidateIssuerSigningKey= true,

                        
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SigningKey"]))
                    };
                });


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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}