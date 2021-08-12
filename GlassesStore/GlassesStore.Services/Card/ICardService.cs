using GlassesStore.Services.Card.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Card
{
    public interface ICardService
    {
        IEnumerable<CardServiceModel> GetCardsForUser(string id);

        bool MakePurchase(int cardId, int productId);

        IEnumerable<PurchaseServiceModel> MyPurchases(string id);
    }
}
