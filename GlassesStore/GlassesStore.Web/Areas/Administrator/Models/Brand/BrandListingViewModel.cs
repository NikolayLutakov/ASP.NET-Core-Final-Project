using GlassesStore.Services.Brand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Models.Brand
{
    public class BrandListingViewModel
    {
        public const int BrandsPerPage = GlassesStore.Models.Common.Constants.Paging.BrandsPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalBrands { get; set; }

        public IEnumerable<BrandServiceModel> Brands { get; set; }
    }
}
