using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Comment.Models
{
    public class CommentServiceModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string CreatedOn { get; set; }

        public string UserId { get; set; }

        public int GlassesId { get; set; }

    }
}
