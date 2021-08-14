namespace GlassesStore.Services.Card
{
    using GlassesStore.Services.Card.Models;
    using System;
    using System.Collections.Generic;
    public interface ICardService
    {
        IEnumerable<CardServiceModel> GetCardsForUser(string id);

        bool MakePurchase(int cardId, int productId, decimal price);

        PurchaseListingServiceModel MyPurchases(
            int currentPage,
            int cardsPerPage,
            string userId);

        bool Add(
            string number,
            DateTime expiresOn,
            string userId,
            int cardTypeId);

        bool Edit(
            int cardId,
            string number,
            DateTime expiresOn,
            string userId,
            int cardTypeId);

        CardServiceModel GetById(int cardId);

        IEnumerable<CardTypeServiceModel> GetCardTypes();

        CardListingServiceModel ListAllCardsForUser(
            int currentPage,
            int cardsPerPage,
            string userId);
    }
}
