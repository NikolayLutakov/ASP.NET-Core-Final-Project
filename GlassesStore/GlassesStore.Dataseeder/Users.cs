using GlassesStore.Data;
using GlassesStore.Models;
using Microsoft.AspNetCore.Identity;
using static GlassesStore.Models.Common.Constants.AdministratorConstants;
using System.Threading.Tasks;

namespace GlassesStore.Dataseeder
{
    public class Users
    {
        private readonly GlassesDbContext data;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public Users(
            GlassesDbContext data, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.data = data;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Seed()
        {
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
