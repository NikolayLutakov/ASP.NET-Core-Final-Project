namespace GlassesStore.Services.Contacts.Models
{
    using System.Collections.Generic;
    public class ContactMessageListingServiceModel
    {
        public const int MessagesPerPage = Constants.Constants.Paging.MessagesPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalMessages { get; set; }

        public IEnumerable<ContactMessageServiceModel> Messages { get; set; }
    }
}
