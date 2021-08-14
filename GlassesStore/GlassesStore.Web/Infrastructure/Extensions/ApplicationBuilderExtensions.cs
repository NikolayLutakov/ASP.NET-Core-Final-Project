namespace GlassesStore.Web.Infrastructure.Extensions
{
    using System;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using GlassesStore.Dataseeder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabse(services);

            SeedAdministrator(services);

            SeedGlassesTypes(services);

            SeedCardTypes(services);

            return app;
        }

        private static void MigrateDatabse(IServiceProvider services)
        {
            var data = services.GetRequiredService<GlassesDbContext>();

            data.Database.Migrate();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var data = services.GetRequiredService<GlassesDbContext>();

            var seeder = new Dataseeder(userManager, roleManager, data);

            seeder.SeedUsers();
        }

        private static void SeedGlassesTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<GlassesDbContext>();
            var seeder = new Dataseeder(data);

            seeder.SeedGlassesTypes();

        }

        private static void SeedCardTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<GlassesDbContext>();
            var seeder = new Dataseeder(data);

            seeder.SeedCardTypes();
        }
    }
}
