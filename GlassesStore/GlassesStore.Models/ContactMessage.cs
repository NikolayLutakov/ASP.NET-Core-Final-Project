namespace GlassesStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Constants.Constants.Contacts;
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        [Display(Name = "*Subject")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
