namespace GlassesStore.Test.Routing.Admin
{
    using GlassesStore.Web.Models.Comment;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using Web.Areas.Administrator.Controllers;
    public class CommentControllerTest
    {
        [Fact]
        public void AllCommentsRouteShouldBeMapped()
       => MyRouting
           .Configuration()
           .ShouldMap("/Administrator/Comment/AllComments")
           .To<CommentController>(c => c.AllComments(With.Any<CommentListingViewModel>()));
    }
}
