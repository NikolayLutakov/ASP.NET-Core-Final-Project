using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GlassesStore.Models.Common.Constants;

namespace GlassesStore.Web.Areas.Administrator.Models.Brand
{
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
