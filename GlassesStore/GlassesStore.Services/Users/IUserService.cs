namespace GlassesStore.Services.Users
{
    using System.Collections.Generic;
    using GlassesStore.Services.Users.Models;
    public interface IUserService
    {
        UserListingServiceModel All(int currentPage, int usersPerPage);

        bool MakeAdmin(string id);

        bool RevokeAdmin(string id);


    }
}
