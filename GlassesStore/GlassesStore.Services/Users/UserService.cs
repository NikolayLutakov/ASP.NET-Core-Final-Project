using GlassesStore.Data;
using GlassesStore.Models;
using GlassesStore.Services.Users.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using static GlassesStore.Models.Common.Constants.AdministratorConstants;

namespace GlassesStore.Services.Users
{
    public class UserService : IUserService
    {
        private readonly GlassesDbContext data;
        private readonly UserManager<User> userManager;

        public UserService(GlassesDbContext data, UserManager<User> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }

        public string IdByUser(string id)
            => this.data
                .Users
                .Where(d => d.Id == id)
                .Select(d => d.Id)
                .FirstOrDefault();

        public IEnumerable<UserServiceModel> All()
        {

            var users = userManager.Users.Where(x => x.UserName != AdministratorUsername).Select(x => new UserServiceModel
            {
                Id = x.Id,
                UserName = x.UserName,
                Roles = userManager.GetRolesAsync(x).GetAwaiter().GetResult()
            })
            .ToList();



            return users;
        }

        public bool MakeAdmin(string id)
        {
            var user = userManager.FindByIdAsync(id).GetAwaiter().GetResult();

            if (user == null)
            {
                return false;
            }

            userManager.AddToRoleAsync(user, AdministratorRoleName).GetAwaiter().GetResult();
            return true;
        }

        public bool RevokeAdmin(string id)
        {
            var user = userManager.FindByIdAsync(id).GetAwaiter().GetResult();

            if (user == null || user.UserName == AdministratorUsername)
            {
                return false;
            }

            userManager.RemoveFromRolesAsync(user, new[] { AdministratorRoleName }).GetAwaiter().GetResult();
            return true;
        }
    }
}
