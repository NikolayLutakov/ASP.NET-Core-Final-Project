namespace GlassesStore.Web.Areas.Administrator.Models.Brand
{
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Constants.Constants;
    public class BrandFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
