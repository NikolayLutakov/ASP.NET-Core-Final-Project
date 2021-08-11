using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int CardId { get; set; }

        public Card Card { get; set; }

        public int GlassesId { get; set; }

        public Glasses Glasses { get; set; }
    }
}
