namespace GlassesStore.Web.Areas.Administrator.Models.Brand
{
    using System.Collections.Generic;
    using GlassesStore.Services.Brand.Models;
    public class BrandListingViewModel
    {
        public const int BrandsPerPage = Constants.Constants.Paging.BrandsPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalBrands { get; set; }

        public IEnumerable<BrandServiceModel> Brands { get; set; }
    }
}
