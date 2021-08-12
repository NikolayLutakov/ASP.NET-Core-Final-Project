namespace GlassesStore.Services.Card
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Card.Models;
    using Microsoft.EntityFrameworkCore;

    public class CardService : ICardService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;

        public CardService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<CardServiceModel> GetCardsForUser(string id)
            => data.Cards
            .Where(x => x.UserId == id).ProjectTo<CardServiceModel>(mapper.ConfigurationProvider)
            .ToList();

        public bool MakePurchase(int cardId, int productId)
        {
            var purchase = new Purchase
            {
                CardId = cardId,
                GlassesId = productId
            };

            try
            {
                data.Purchases.Add(purchase);
                data.SaveChanges();

            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<PurchaseServiceModel> MyPurchases(string id)
            => data.Purchases
            .Where(x => x.Card.User.Id == id)
            .ProjectTo<PurchaseServiceModel>(mapper.ConfigurationProvider)
            .ToList();
    }
}
