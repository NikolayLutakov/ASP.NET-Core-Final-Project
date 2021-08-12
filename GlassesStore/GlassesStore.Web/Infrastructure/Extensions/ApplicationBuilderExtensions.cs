namespace GlassesStore.Web.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using static GlassesStore.Models.Common.Constants.AdministratorConstants;

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

        private static void SeedGlassesTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<GlassesDbContext>();

            if (data.GlassesTypes.Any())
            {
                return;
            }

            data.GlassesTypes.AddRange(new[]
            {
                new GlassesType { Name = "Sunglasses"},
                new GlassesType { Name = "Prescription glasses" },
                new GlassesType { Name = "Lenses"}
            });

            data.SaveChanges();
        }

        private static void SeedCardTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<GlassesDbContext>();

            if (data.CardTypes.Any())
            {
                return;
            }

            data.CardTypes.AddRange(new[]
            {
                new CardType { TypeName = "Debit"},
                new CardType { TypeName = "Credit" },
            });

            data.SaveChanges();
        }
    }
}
