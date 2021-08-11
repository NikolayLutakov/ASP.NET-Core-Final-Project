using GlassesStore.Services.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Users
{
    public interface IUserService
    {
        IEnumerable<UserServiceModel> All();

        bool MakeAdmin(string id);

        bool RevokeAdmin(string id);

        public string IdByUser(string id);
    }
}
