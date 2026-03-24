using BloodApp.Application.IServices;
using BloodApp.Application.Services;
using BloodApp.Domain.IRepositories;
using BloodApp.Domain.Models;
using BloodApp.Infrastructure.DataBase;
using BloodApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
namespace BloodApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ConString");

            
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddScoped<IDonorRepository, DonorRepository>();
            builder.Services.AddScoped<IDonorService, DonorService>();
            builder.Services.AddScoped<IDonationRequestRepository, DonationRequestRepository>();
            builder.Services.AddScoped<IDonationRequestService, DonationRequestService>();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
