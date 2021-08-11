using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GlassesStore.Models.Common.Constants;

namespace GlassesStore.Models
{
    public class GlassesType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string  Name { get; set; }

        public IEnumerable<Glasses> Glasses { get; set; } = new HashSet<Glasses>();
    }
}
