namespace GlassesStore.Web.Models.Shop
{
    using System.Collections.Generic;
    using GlassesStore.Services.Card.Models;
    public class PurchaseListingViewModel
    {
        public const int PurchasesPerPage = Constants.Constants.Paging.PurchasesPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalPurchases { get; set; }

        public string SearchTerm { get; set; }

        public IEnumerable<PurchaseServiceModel> Purchases { get; set; }
    }
}
