namespace GlassesStore.Web.Areas.Administrator.Models.Glasses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using GlassesStore.Services.Glasses.Models;
    using GlassesStore.Services.GlassesType.Models;

    public class AdminGlassesListingViewModel
    {
        public const int GlassesPerPage = Constants.Constants.Paging.GlassesPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalGlasses { get; set; }

        public string SearchTerm { get; set; }

        [Display(Name = "Order By")]
        public string OrderBy { get; set; }

        [Display(Name = "Type")]
        public int FilterByType { get; set; }

        public IEnumerable<GlassesServiceModel> Glasses { get; set; }

        public IEnumerable<GlassesTypeServiceModel> GlassesTypes { get; set; }
    }
}
