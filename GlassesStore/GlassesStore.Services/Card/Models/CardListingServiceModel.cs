namespace GlassesStore.Services.Card.Models
{
    using System.Collections.Generic;
    public class CardListingServiceModel
    {
        public const int CardsPerPage = Constants.Constants.Paging.CardsPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalCards { get; set; }

        public IEnumerable<CardServiceModel> Cards { get; set; }
    }
}
