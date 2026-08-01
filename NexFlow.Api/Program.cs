
using Microsoft.OpenApi;
using NexFlow.Api.Extensions;
using NexFlow.Application.DependencyInjection;
using NexFlow.Infrastructure.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace NexFlow.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .Enrich.WithThreadId()
                    .WriteTo.Console()
                    .WriteTo.File(
                        path: "Logs/log-.txt",
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 30,
                        shared: true);
            });

            Log.Information("===== Serilog inicializado correctamente =====");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerDocumentation(builder.Configuration);

            // Add application and infrastructure services
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            // Add JWT authentication
            builder.Services.AddJwtAuthentication(builder.Configuration);

            var app = builder.Build();

            // Crear roles y usuario administrador|
            await app.InitializeDatabaseAsync();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandling();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
