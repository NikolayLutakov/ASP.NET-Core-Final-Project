using GlassesStore.Services.Card.Models;
using GlassesStore.Services.Glasses.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Models.Shop
{
    public class PurchaseViewModel
    {
        public IEnumerable<CardServiceModel> UserCards { get; set; }

        public GlassesServiceModel ProductToBuy { get; set; }

        [Required]
        [Display(Name = "Card")]
        public int CardId { get; set; }

        public int ProductId { get; set; }
    }
}
