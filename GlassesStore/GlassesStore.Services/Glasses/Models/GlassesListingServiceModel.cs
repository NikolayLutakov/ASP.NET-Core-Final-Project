using GlassesStore.Services.GlassesType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Glasses.Models
{
    public class GlassesListingServiceModel
    {
        public int CurrentPage { get; set; }

        public int TotalGlasses { get; set; }

        public string SearchTerm { get; set; }

        public string OrderBy { get; set; }

        public int FilterByType { get; set; }

        public IEnumerable<GlassesServiceModel> Glasses { get; set; }

        public IEnumerable<GlassesTypeServiceModel> GlassesTypes { get; set; }
    }
}
