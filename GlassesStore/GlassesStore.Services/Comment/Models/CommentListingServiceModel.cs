using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Comment.Models
{
    public class CommentListingServiceModel
    {
        public const int CommentsPerPage = GlassesStore.Models.Common.Constants.Paging.CommentsPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalComments { get; set; }

        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
