namespace GlassesStore.Services.Users.Models
{
    using System.Collections.Generic;
    public class UserListingServiceModel
    {
        public const int UsersPerPage = Constants.Constants.Paging.UsersPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalUsers { get; set; }

        public IEnumerable<UserServiceModel> Users { get; set; }
    }
}
