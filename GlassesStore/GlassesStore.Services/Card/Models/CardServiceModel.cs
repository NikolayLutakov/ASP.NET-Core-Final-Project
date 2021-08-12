using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Card.Models
{
    public class CardServiceModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string ExpiresOn { get; set; }

        public string Type { get; set; }
    }
}
