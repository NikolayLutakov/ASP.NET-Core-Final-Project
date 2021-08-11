using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GlassesStore.Models.Common.Constants;

namespace GlassesStore.Models
{
    public class Glasses
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int TypeId { get; set; }

        public GlassesType Type { get; set; }

        public IEnumerable<GlassesRating> GlassesRatings { get; set; } = new HashSet<GlassesRating>();

        public IEnumerable<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        public IEnumerable<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
