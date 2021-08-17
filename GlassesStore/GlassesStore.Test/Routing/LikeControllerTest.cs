namespace GlassesStore.Test.Routing
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Shop;

    public class LikeControllerTest
    {
        [Theory]
        [InlineData(1, null)]

        public void LikeRouteShouldBeMapped(int productId, string callerView)
           => MyRouting
               .Configuration()
               .ShouldMap("/Like/Like?productId=1")
               .To<LikeController>(c => c.Like(productId, callerView, With.Any<GlassesListingViewModel>()));

        [Theory]
        [InlineData(1, null)]
        public void UnlikeRouteShouldBeMapped(int productId, string callerView)
           => MyRouting
               .Configuration()
               .ShouldMap("/Like/Unlike?productId=1")
               .To<LikeController>(c => c.Unlike(productId, callerView));

        [Fact]
        public void MyLikesRouteShouldBeMaped()
            => MyRouting
                .Configuration()
            .ShouldMap("/Like/MyLikes")
            .To<LikeController>(c => c.MyLikes(With.Any<GlassesListingViewModel>()));
    }
}
