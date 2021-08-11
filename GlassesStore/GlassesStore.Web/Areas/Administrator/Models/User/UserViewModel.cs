using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Models.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public int OwnedBooks { get; set; }
    }
}
