using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Card.Models
{
    public class CardListingServiceModel
    {
        public const int CardsPerPage = GlassesStore.Models.Common.Constants.Paging.CardsPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalCards { get; set; }

        public string SearchTerm { get; set; }

        public IEnumerable<CardServiceModel> Cards { get; set; }
    }
}
