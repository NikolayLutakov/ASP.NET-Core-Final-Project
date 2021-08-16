namespace GlassesStore.Services.Contacts
{
    using Microsoft.EntityFrameworkCore;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Contacts.Models;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class ContactService : IContactService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;

        public ContactService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public bool AddMessage(string name, string email, string subject, string message)
        {
            var contactMessage = new ContactMessage
            {
                Name = name,
                Email = email,
                Subject = subject,
                Message = message,
                IsRead = false
            };

            try
            {
                data.ContactMessages.Add(contactMessage);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public ContactMessageListingServiceModel All(
            int currentPage,
            int commentsPerPage)
        {
            var messagesQuery = data.ContactMessages
               .OrderByDescending(x => x.CreatedOn);

            var totalMessages = messagesQuery.Count();

            var messages = messagesQuery.Skip((currentPage - 1) * commentsPerPage)
                .Take(commentsPerPage)
                .ProjectTo<ContactMessageServiceModel>(mapper.ConfigurationProvider);

            return new ContactMessageListingServiceModel
            {
                TotalMessages = totalMessages,
                Messages = messages,
                CurrentPage = currentPage
            };
        }

        public bool MarkRead(int id)
        {
            var messageToUpdate = data.ContactMessages.Find(id);

            if (messageToUpdate == null)
            {
                return false;
            }

            messageToUpdate.IsRead = true;

            try
            {
                data.ContactMessages.Update(messageToUpdate);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool MarkUnread(int id)
        {
            var messageToUpdate = data.ContactMessages.Find(id);

            if (messageToUpdate == null)
            {
                return false;
            }

            messageToUpdate.IsRead = false;

            try
            {
                data.ContactMessages.Update(messageToUpdate);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
