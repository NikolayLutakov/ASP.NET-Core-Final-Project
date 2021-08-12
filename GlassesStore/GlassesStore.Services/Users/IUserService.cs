namespace GlassesStore.Services.Users
{
    using System.Collections.Generic;
    using GlassesStore.Models;
    using GlassesStore.Services.Users.Models;
    public interface IUserService
    {
        IEnumerable<UserServiceModel> All();

        bool MakeAdmin(string id);

        bool RevokeAdmin(string id);


    }
}
