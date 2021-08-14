namespace GlassesStore.Web.Areas.Administrator.Models.User
{
    using System.Collections.Generic;
    using GlassesStore.Services.Users.Models;

    public class UserListingViewModel
    {
        public const int UsersPerPage = GlassesStore.Models.Common.Constants.Paging.UsersPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalUsers { get; set; }

        public IEnumerable<UserServiceModel> Users { get; set; }
    }
}
