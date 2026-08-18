using System.Runtime.InteropServices.Marshalling;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiNegocio.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
