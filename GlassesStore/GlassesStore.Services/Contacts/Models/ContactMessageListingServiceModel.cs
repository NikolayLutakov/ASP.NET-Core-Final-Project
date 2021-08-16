using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Contacts.Models
{
    public class ContactMessageListingServiceModel
    {
        public const int MessagesPerPage = GlassesStore.Models.Common.Constants.Paging.MessagesPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalMessages { get; set; }

        public IEnumerable<ContactMessageServiceModel> Messages { get; set; }
    }
}
