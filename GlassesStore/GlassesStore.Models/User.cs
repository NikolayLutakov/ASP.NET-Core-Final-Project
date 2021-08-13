namespace GlassesStore.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {

        public IEnumerable<GlassesLike> GlassesRatings { get; set; } = new HashSet<GlassesLike>();

        public IEnumerable<Card> Cards { get; set; } = new HashSet<Card>();

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
