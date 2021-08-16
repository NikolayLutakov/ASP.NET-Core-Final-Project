namespace GlassesStore.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Models.Common.Constants.Contacts;
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        [Display(Name = "*Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        [Display(Name = "*Your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(SubjectMinLength)]
        [MaxLength(SubjectMaxLength)]
        [Display(Name = "*Subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(MessageMinLength)]
        [MaxLength(MessageMaxLength)]
        [Display(Name ="*Your Message")]
        public string Message { get; set; }
    }
}
