
using Korean_Api.Database;
using Korean_Api.Implemantaion;
using Korean_Api.Interface;
using Korean_Api.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Korean_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IActor,ActorImplementation>();
            builder.Services.AddScoped<ApiKeyAuthetication>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
         
            //connecting to the database
            //databse connection
            string? con = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<KoreanContext>(builder => { builder.UseSqlServer(con).EnableSensitiveDataLogging(); });
            builder.Services.TryAddScoped<IUsers, UserImplementaion>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}