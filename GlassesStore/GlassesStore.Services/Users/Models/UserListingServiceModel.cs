using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Users.Models
{
    public class UserListingServiceModel
    {
        public const int UsersPerPage = GlassesStore.Models.Common.Constants.Paging.UsersPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalUsers { get; set; }

        public IEnumerable<UserServiceModel> Users { get; set; }
    }
}
