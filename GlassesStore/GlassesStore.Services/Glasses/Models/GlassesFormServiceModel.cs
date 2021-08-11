using GlassesStore.Services.Brand.Models;
using GlassesStore.Services.GlassesType.Models;
using System.Collections.Generic;

namespace GlassesStore.Services.Glasses.Models
{
    public class GlassesFormServiceModel
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int BrandId { get; set; }

        public int TypeId { get; set; }

        public IEnumerable<BrandServiceModel> BrandList { get; set; }

        public IEnumerable<GlassesTypeServiceModel> TypeList { get; set; }


    }
}
