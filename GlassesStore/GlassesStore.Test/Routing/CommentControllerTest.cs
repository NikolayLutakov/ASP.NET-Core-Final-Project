namespace GlassesStore.Test.Routing
{
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Comment;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class CommentControllerTest
    {
        [Theory]
        [InlineData(1)]
        public void AddRouteShouldBeMapped(int id)
         => MyRouting
             .Configuration()
             .ShouldMap("/Comment/Add/1")
             .To<CommentController>(c => c.Add(id));

        [Fact]
        public void PostAddRouteShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap(request => request
              .WithPath("/Comment/Add")
              .WithMethod(HttpMethod.Post))
              .To<CommentController>(c => c.Add(With.Any<CommentFormViewModel>()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int id)
         => MyRouting
             .Configuration()
             .ShouldMap("/Comment/Edit?commentId=1")
             .To<CommentController>(c => c.Edit(id));

        [Fact]
        public void PostEditRouteShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap(request => request
              .WithPath("/Comment/Edit")
              .WithMethod(HttpMethod.Post))
              .To<CommentController>(c => c.Edit(With.Any<CommentFormViewModel>(), null));


        [Theory]
        [InlineData(1, 1, null)]
        public void DeleteRouteShouldBeMapped(int commentId, int productId, string callerView)
        => MyRouting
            .Configuration()
            .ShouldMap("/Comment/Delete?commentId=1&productId=1")
            .To<CommentController>(c => c.Delete(commentId, productId, callerView));

        [Fact]
        public void MyCommentsRouteShouldBeMapped()
        => MyRouting
            .Configuration()
            .ShouldMap("/Comment/MyComments")
            .To<CommentController>(c => c.MyComments(With.Any<CommentListingViewModel>()));
    }
}
