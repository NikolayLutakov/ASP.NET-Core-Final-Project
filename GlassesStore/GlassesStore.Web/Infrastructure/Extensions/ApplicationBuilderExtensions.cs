using GlassesStore.Data;
using GlassesStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GlassesStore.Models.Common.Constants.AdministratorConstants;


namespace GlassesStore.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabse(services);

            SeedAdministrator(services);

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

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministratorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = AdministratorUsername;
                    const string adminPassword = AdministratorPassword;

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
