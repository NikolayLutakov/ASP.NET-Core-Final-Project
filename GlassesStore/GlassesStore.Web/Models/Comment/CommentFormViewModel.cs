namespace GlassesStore.Web.Models.Comment
{
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Constants.Constants.Comment;

    public class CommentFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public string UserId { get; set; }

        public int GlassesId { get; set; }
    }
}
