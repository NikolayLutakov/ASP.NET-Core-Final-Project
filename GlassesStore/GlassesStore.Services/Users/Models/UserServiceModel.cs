namespace GlassesStore.Services.Users.Models
{
    using System.Collections.Generic;
    public class UserServiceModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}
