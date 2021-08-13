using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Brand.Models
{
    public class BrandListingServiceModel
    {
        public int CurrentPage { get; set; }

        public int TotalBrands { get; set; }

        public IEnumerable<BrandServiceModel> Brands { get; set; }
    }
}
