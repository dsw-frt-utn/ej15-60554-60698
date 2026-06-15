
using Dsw2026Ej15.Data;

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
            builder.Services.AddSingleton<PersistenceInMemory>();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            // pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();
            app.MapHealthChecks("/health-check");

            app.Run();
        }
    }
}
