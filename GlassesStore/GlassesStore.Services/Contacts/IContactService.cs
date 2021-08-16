namespace GlassesStore.Services.Contacts
{
    using GlassesStore.Services.Contacts.Models;
    public interface IContactService
    {
        bool AddMessage(
            string name, 
            string email, 
            string subject, 
            string message);

        ContactMessageListingServiceModel All(
            int currentPage,
            int commentsPerPage);

        bool MarkRead(int id);

        bool MarkUnread(int id);
    }
}
