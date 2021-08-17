namespace GlassesStore.Models
{
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Constants.Constants;
    public class CardType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string TypeName { get; set; }
    }
}
