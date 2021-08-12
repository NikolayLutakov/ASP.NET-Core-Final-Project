namespace GlassesStore.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {

        public IEnumerable<GlassesRating> GlassesRatings { get; set; } = new HashSet<GlassesRating>();

        public IEnumerable<Card> Cards { get; set; } = new HashSet<Card>();

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
