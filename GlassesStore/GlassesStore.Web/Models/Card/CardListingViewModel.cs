using GlassesStore.Services.Card.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Models.Card
{
    public class CardListingViewModel
    {
        public const int CardsPerPage = GlassesStore.Models.Common.Constants.Paging.CardsPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalCards { get; set; }

        public IEnumerable<CardServiceModel> Cards { get; set; }
    }
}
