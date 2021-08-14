namespace GlassesStore.Web.Infrastructure.Extensions
{
    using System;
    using GlassesStore.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using GlassesStore.Services.Dataseed.UsersSeed;
    using GlassesStore.Services.Dataseed.GlassesTypesSeed;
    using GlassesStore.Services.Dataseed.CardTypesSeed;

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
            var userSeedService = services.GetRequiredService<IUserSeedService>();

            userSeedService.Seed();
        }

        private static void SeedGlassesTypes(IServiceProvider services)
        {
            var glassesTypeSeedService = services.GetRequiredService<IGlassesTypeSeedService>();

            glassesTypeSeedService.Seed();

        }

        private static void SeedCardTypes(IServiceProvider services)
        {
            var cardTypeSeedService = services.GetRequiredService<ICardTypeSeedService>();

            cardTypeSeedService.Seed();
        }
    }
}
