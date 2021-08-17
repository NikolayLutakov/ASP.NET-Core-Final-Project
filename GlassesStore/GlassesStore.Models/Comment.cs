namespace GlassesStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static GlassesStore.Constants.Constants.Comment;
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public User User { get; set; }

        public int GlassesId { get; set; }

        public Glasses Glasses { get; set; }
    }
}
