namespace GlassesStore.Services.Dataseed.ContactMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GlassesStore.Data;
    using GlassesStore.Models;
    public class ContactMessageSeedService : IContactMessageSeedService
    {
        private readonly GlassesDbContext data;

        public ContactMessageSeedService(GlassesDbContext data)
        {
            this.data = data;
        }

        public void Seed()
        {
            if (data.ContactMessages.Any())
            {
                return;
            }

            var messages = new List<ContactMessage>()
            {
                new ContactMessage
                {
                    Name = "Sample Name1",
                    Email = "samplemail1@mail.com",
                    Message = "Some sample message.",
                    Subject = "subject",
                    IsRead = true,
                    CreatedOn = DateTime.Parse("2021-08-15")
                },
                new ContactMessage
                {
                    Name = "Sample Name2",
                    Email = "samplemail2@mail.com",
                    Message = "Some sample message.",
                    Subject = "subject",
                    IsRead = true,
                    CreatedOn = DateTime.Parse("2021-08-10")
                },
                new ContactMessage
                {
                    Name = "Sample Name3",
                    Email = "samplemail3@mail.com",
                    Message = "Some sample message.",
                    Subject = "subject",
                    IsRead = false,
                    CreatedOn = DateTime.Parse("2021-08-16")
                },
                new ContactMessage
                {
                    Name = "Sample Name4",
                    Email = "samplemail4@mail.com",
                    Message = "Some sample message.",
                    Subject = "subject",
                    IsRead = false,
                    CreatedOn = DateTime.Parse("2021-08-12")
                }
            };

            data.ContactMessages.AddRange(messages);
            data.SaveChanges();
        }
    }
}
