namespace GlassesStore.Test.Controllers.Admin
{
    using GlassesStore.Web.Areas.Administrator.Controllers;
    using GlassesStore.Web.Models.Comment;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using static Constants.Constants.AdministratorConstants;
    public class CommentControllerTest
    {
        [Fact]
        public void AllCommentsShouldReturnViewWithModel()
          => MyController<CommentController>
              .Instance(c => c.WithUser(new[] { AdministratorRoleName }))
              .Calling(c => c.AllComments(new CommentListingViewModel()))
              .ShouldReturn()
              .View((view => view
                  .WithModelOfType<CommentListingViewModel>()));
    }
}
