namespace GlassesStore.Dataseeder
{
    using GlassesStore.Data;
    using GlassesStore.Models;
    using System.Linq;

    public class CardTypes
    {
        private readonly GlassesDbContext data;

        public CardTypes(GlassesDbContext data)
        {
            this.data = data;
        }

        public void Seed()
        {
            if (data.CardTypes.Any())
            {
                return;
            }

            data.CardTypes.AddRange(new[]
            {
                new CardType { TypeName = "Debit"},
                new CardType { TypeName = "Credit" },
            });

            data.SaveChanges();
        }
    }
}
