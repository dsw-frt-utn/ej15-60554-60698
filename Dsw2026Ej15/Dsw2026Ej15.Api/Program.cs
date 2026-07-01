
using Dsw2026Ej15.Api.Middleware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = "Host=localhost;Port=5432;Database=FirstDB;Username=postgres;Password=daniel123";

            builder.Services.AddDbContext<Dsw2026Ej15DbContext>(options=>
            {
                options.UseNpgsql(connectionString);
            });

            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();

            //Swagger para ver endpoints
            builder.Services.AddSwaggerGen();

            //Persistencia en base de datos
            builder.Services.AddScoped<IPersistence, PersistenceEF>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            app.MapControllers();
            app.MapHealthChecks("/health-check");

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Dsw2026Ej15DbContext>(); // reemplazá por tu DbContext real

                if (!context.Specialities.Any())
                {
                    string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
                    var json = File.ReadAllText(jsonPath);

                    var specialities = JsonSerializer.Deserialize<List<Speciality>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    context.Specialities.AddRange(specialities);
                    context.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
