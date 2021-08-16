namespace GlassesStore.Services.Contacts.Models
{
    public class ContactMessageServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string CreatedOn { get; set; }
    }
}
