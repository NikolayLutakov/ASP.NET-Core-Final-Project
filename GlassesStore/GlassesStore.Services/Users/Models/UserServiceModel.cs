using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Users.Models
{
    public class UserServiceModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}
