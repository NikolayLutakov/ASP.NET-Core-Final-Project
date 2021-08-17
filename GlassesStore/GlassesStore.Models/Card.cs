namespace GlassesStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Constants.Constants.Card;
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NumberMaxLength)]
        public string Number { get; set; }

        public DateTime ExpiresOn { get; set; }

        public CardType Type { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}
