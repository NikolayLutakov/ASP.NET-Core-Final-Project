namespace GlassesStore.Web.Models.Card
{
    using System.Collections.Generic;
    using GlassesStore.Services.Card.Models;

    public class CardListingViewModel
    {
        public const int CardsPerPage = Constants.Constants.Paging.CardsPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalCards { get; set; }

        public IEnumerable<CardServiceModel> Cards { get; set; }
    }
}
