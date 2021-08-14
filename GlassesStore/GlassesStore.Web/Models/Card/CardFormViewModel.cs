namespace GlassesStore.Web.Models.Card
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using GlassesStore.Services.Card.Models;
    using static GlassesStore.Models.Common.Constants.Card;
    public class CardFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NumberMaxLength)]
        [RegularExpression(validationString, ErrorMessage = "Number must be 16 digits long")]
        [Display(Name = "Card Number")]
        public string Number { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expires On")]
        public DateTime ExpiresOn { get; set; } = DateTime.Now;

        [Display(Name = "Card Type")]
        public int TypeId { get; set; }

        public IEnumerable<CardTypeServiceModel> TypesList { get; set; }

    }
}
