using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GlassesStore.Models.Common.Constants.Card;

namespace GlassesStore.Models
{
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
