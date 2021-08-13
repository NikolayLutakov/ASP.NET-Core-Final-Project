namespace GlassesStore.Models
{
    using System;
    public class Purchase
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int CardId { get; set; }

        public Card Card { get; set; }

        public int GlassesId { get; set; }

        public Glasses Glasses { get; set; }

        public decimal Cost { get; set; }
    }
}
