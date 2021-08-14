using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Card.Models
{
    public class PurchaseListingServiceModel
    {
        public const int PurchasesPerPage = GlassesStore.Models.Common.Constants.Paging.PurchasesPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalPurchases { get; set; }

        public string SearchTerm { get; set; }

        public IEnumerable<PurchaseServiceModel> Purchases { get; set; }
    }
}
