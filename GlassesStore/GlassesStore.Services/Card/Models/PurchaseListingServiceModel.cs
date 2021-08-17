namespace GlassesStore.Services.Card.Models
{
    using System.Collections.Generic;
    public class PurchaseListingServiceModel
    {
        public const int PurchasesPerPage = Constants.Constants.Paging.PurchasesPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalPurchases { get; set; }

        public string SearchTerm { get; set; }

        public IEnumerable<PurchaseServiceModel> Purchases { get; set; }
    }
}
