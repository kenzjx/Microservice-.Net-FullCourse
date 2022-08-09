using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PlatformService.Data
{
     public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    RelationalDatabaseFacadeExtensions.Migrate(context.Database);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Server Express", Publisher="Microsoft",  Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation",  Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}