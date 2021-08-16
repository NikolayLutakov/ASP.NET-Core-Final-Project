namespace GlassesStore.Web.Models.Home
{
    using GlassesStore.Services.Contacts.Models;
    using System.Collections.Generic;

    public class ContactMessagesListingViewModel
    {
        public const int MessagesPerPage = GlassesStore.Models.Common.Constants.Paging.MessagesPerPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalMessages { get; set; }

        public IEnumerable<ContactMessageServiceModel> Messages { get; set; }
    }
}
