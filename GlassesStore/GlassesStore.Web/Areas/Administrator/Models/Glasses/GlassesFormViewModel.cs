using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GlassesStore.Services.Brand.Models;
using GlassesStore.Services.GlassesType.Models;
using static GlassesStore.Models.Common.Constants;

namespace GlassesStore.Web.Areas.Administrator.Models.Glasses
{
    public class GlassesFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Display(Name = "Model")]
        public string ModelName { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Image")]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public IEnumerable<BrandServiceModel> BrandList { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int TypeId { get; set; }

        public IEnumerable<GlassesTypeServiceModel> TypeList { get; set; }
    }
}
