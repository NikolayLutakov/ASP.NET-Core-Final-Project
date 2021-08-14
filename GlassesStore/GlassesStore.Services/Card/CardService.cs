namespace GlassesStore.Services.Card
{
    using System;
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

        public bool Add(
            string number, 
            DateTime expiresOn, 
            string userId, 
            int cardTypeId)
        {
            var cardType = data.CardTypes.Find(cardTypeId);

            if (cardType == null)
            {
                return false;
            }

            var card = new Card
            {
                Number = number,
                ExpiresOn = expiresOn,
                UserId = userId,
                Type = cardType
            };

            try
            {
                data.Cards.Add(card);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<CardServiceModel> GetCardsForUser(string id)
            => data.Cards
            .OrderByDescending(x => x.ExpiresOn)
            .Where(x => x.UserId == id).ProjectTo<CardServiceModel>(mapper.ConfigurationProvider)
            .ToList();

        public IEnumerable<CardTypeServiceModel> GetCardTypes()
            => data.CardTypes
            .ProjectTo<CardTypeServiceModel>(mapper.ConfigurationProvider)
            .ToList();

        public bool MakePurchase(int cardId, int productId, decimal price)
        {
            var purchase = new Purchase
            {
                CardId = cardId,
                GlassesId = productId,
                Cost = price
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

        public PurchaseListingServiceModel MyPurchases(
            int currentPage,
            int cardsPerPage,
            string userId)
        {
            var purchasesQuery = data.Purchases
            .OrderByDescending(x => x.Date)
            .Where(x => x.Card.User.Id == userId);

            var totalPurchases = purchasesQuery.Count();

            var purchases = purchasesQuery.Skip((currentPage - 1) * cardsPerPage)
                .Take(cardsPerPage).ProjectTo<PurchaseServiceModel>(mapper.ConfigurationProvider);

            return new PurchaseListingServiceModel
            {
                TotalPurchases = totalPurchases,
                Purchases = purchases,
                CurrentPage = currentPage
            };
        }
            

        public CardListingServiceModel ListAllCardsForUser(
            int currentPage, 
            int cardsPerPage, 
            string userId)
        {
            var cardsQuery = GetCardsForUser(userId);

            var totalCards = cardsQuery.Count();

            var cards = cardsQuery.Skip((currentPage - 1) * cardsPerPage)
                .Take(cardsPerPage);

            return new CardListingServiceModel
            {
                TotalCards = totalCards,
                Cards = cards,
                CurrentPage = currentPage
            };
        }

        public CardServiceModel GetById(int cardId)
            => data.Cards
            .Where(x => x.Id == cardId)
            .ProjectTo<CardServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefault();

        public bool Edit(
            int cardId, 
            string number, 
            DateTime expiresOn, 
            string userId, 
            int cardTypeId)
        {
            var cardType = data.CardTypes.Find(cardTypeId);

            if (cardType == null)
            {
                return false;
            }

            var card = data.Cards.Find(cardId);

            if (card == null)
            {
                return false;
            }

            if (card.UserId != userId)
            {
                return false;
            }

            card.Number = number;
            card.ExpiresOn = expiresOn;
            card.Type = cardType;

            try
            {
                data.Cards.Update(card);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
