﻿using System.ComponentModel.DataAnnotations;
using static GlassesStore.Models.Common.Constants;


namespace GlassesStore.Models
{
    public class CardType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string TypeName { get; set; }
    }
}
