using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Models.Glasses
{
    public class GlassesViewModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public decimal Rating { get; set; }

        public int PurchasesCount { get; set; }
    }
}
