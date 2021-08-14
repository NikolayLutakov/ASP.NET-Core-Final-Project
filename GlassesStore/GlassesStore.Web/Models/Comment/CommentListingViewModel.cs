namespace GlassesStore.Web.Models.Comment
{
    using GlassesStore.Services.Comment.Models;
    using System.Collections.Generic;

    public class CommentListingViewModel
    {
        public const int CommentsPerPage = GlassesStore.Models.Common.Constants.Paging.CommentsPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalComments { get; set; }

        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
