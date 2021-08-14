namespace GlassesStore.Services.Users
{
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Users.Models;
    using static GlassesStore.Models.Common.Constants.AdministratorConstants;

    public class UserService : IUserService
    {
        private readonly GlassesDbContext data;
        private readonly UserManager<User> userManager;

        public UserService(GlassesDbContext data, UserManager<User> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }

        public UserListingServiceModel All(int currentPage, int usersPerPage)
        {

            var usersQuery = userManager.Users
                .OrderBy(x => x.UserName)
                .Where(x => x.UserName != AdministratorUsername)
                .Select(x => new UserServiceModel
            {
                Id = x.Id,
                UserName = x.UserName,
                Role = userManager
                .GetRolesAsync(x)
                .GetAwaiter()
                .GetResult()
                .FirstOrDefault()
            });

            
            var totalUsers = usersQuery.Count();

            var users = usersQuery.Skip((currentPage - 1) * usersPerPage)
                .Take(usersPerPage);

            return new UserListingServiceModel
            {
                TotalUsers = totalUsers,
                Users = users,
                CurrentPage = currentPage
            };

           
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
