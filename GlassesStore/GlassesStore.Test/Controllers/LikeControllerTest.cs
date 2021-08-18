namespace GlassesStore.Test.Controllers
{
    using GlassesStore.Models;
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Shop;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class LikeControllerTest
    {
        [Theory]
        [InlineData(1)]
        public void LikeShouldReturnRedirectToMyLikes(int productId)
           => MyController<LikeController>
               .Instance(c => c.WithUser())
               .Calling(c => c.Like(productId, null, new GlassesListingViewModel()))
            .ShouldReturn()
               .Redirect(redirect => redirect
                   .To<LikeController>(c => c.MyLikes(With.Any<GlassesListingViewModel>())));

        [Theory]
        [InlineData(1, "TestId")]
        public void UnlikeShouldReturnRedirectToMyLikes(int productId, string userId)
           => MyController<LikeController>
               .Instance(c => c.WithUser()
               .WithData(d => d.WithEntities(e => 
               {
                   var like = new GlassesLike
                   {
                       GlassesId = productId,
                       UserId = userId
                   };

                   e.Add(like);
               })))
               .Calling(c => c.Unlike(productId, null))
            .ShouldReturn()
               .Redirect(redirect => redirect
                   .To<LikeController>(c => c.MyLikes(With.Any<GlassesListingViewModel>())));
    }
}
