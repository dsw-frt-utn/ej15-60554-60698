
using Dsw2026Ej15.Api.Middleware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddHealthChecks();


            //Swagger para ver endpoints
            builder.Services.AddSwaggerGen();

            //Persistencia en memoria
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

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

            app.Run();
        }
    }
}
