using System;
using System.Collections.Generic;
using System.Linq;
namespace GlassesStore.Models
{
    public class GlassesLike
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int GlassesId { get; set; }

        public Glasses Glasses { get; set; }
    }
}
