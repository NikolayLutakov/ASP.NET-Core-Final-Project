namespace GlassesStore.Web.Areas.Administrator.Models.Glasses
{
    using System.Collections.Generic;
    using GlassesStore.Services.Glasses.Models;

    public class AdminGlassesListingViewModel
    {
        public const int GlassesPerPage = GlassesStore.Models.Common.Constants.Paging.GlassesPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalGlasses { get; set; }

        public string SearchTerm { get; set; }

        public IEnumerable<GlassesServiceModel> Glasses { get; set; }
    }
}
