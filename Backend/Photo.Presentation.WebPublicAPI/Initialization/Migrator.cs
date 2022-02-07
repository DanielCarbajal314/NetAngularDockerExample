using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Photo.Infrastructure.EFPersistency.EF;
using System;

namespace Photo.Presentation.WebPublicAPI.Initialization
{
    public static class Migrator
    {
        public static void Migrate(this IApplicationBuilder builder)
        {
            Console.WriteLine("Migrating...");
            using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<PhotoDbContext>())
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }

            }
        }
    }
}
