using NexFlow.Infrastructure.Identity;

namespace NexFlow.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var seeder = scope.ServiceProvider.GetRequiredService<IdentitySeeder>();
            await seeder.SeedAsync();
        }
    }
}
