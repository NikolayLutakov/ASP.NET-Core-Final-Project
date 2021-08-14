namespace GlassesStore.Dataseeder
{
    using GlassesStore.Data;
    using GlassesStore.Models;
    using Microsoft.AspNetCore.Identity;

    public class Dataseeder
    {
        private readonly GlassesDbContext data;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public Dataseeder(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, 
            GlassesDbContext data)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.data = data;
        }



        public Dataseeder(GlassesDbContext data)
        {
            this.data = data;
        }

        public void SeedUsers()
        {
            var users = new Users(data, userManager, roleManager);
            users.Seed();
        }

        public void SeedCardTypes()
        {
            var cardTypes = new CardTypes(data);
            cardTypes.Seed();
        }

        public void SeedGlassesTypes()
        {
            var glassesTypes = new GlassesTypes(data);
            glassesTypes.Seed();
        }
    }
}
