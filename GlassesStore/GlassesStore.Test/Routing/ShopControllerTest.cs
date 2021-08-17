namespace GlassesStore.Test.Routing
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Shop;

    public class ShopControllerTest
    {
        [Fact]
        public void IndexShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap("/Shop/")
            .To<ShopController>(c => c.Index(With.Any<GlassesListingViewModel>()));

        [Theory]
        [InlineData(1)]
        public void DetailsShouldMapRoute(int id)
            => MyRouting
            .Configuration()
            .ShouldMap("/Shop/Details/1")
            .To<ShopController>(c => c.Details(id));

        [Theory]
        [InlineData(1)]
        public void BuyShouldMapRoute(int id)
            => MyRouting
            .Configuration()
            .ShouldMap("/Shop/Buy/1")
            .To<ShopController>(c => c.Buy(id));

        [Fact]
        public void PostBuyShouldMapRoute()
           => MyRouting
            .Configuration()
            .ShouldMap(request =>
                request.WithPath("/Shop/Buy")
                .WithMethod(HttpMethod.Post))
            .To<ShopController>(c => c.Buy(With.Any<PurchaseViewModel>()));

        [Fact]
        public void MyPurchasesShoudMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap("/Shop/MyPurchases")
            .To<ShopController>(c => c.MyPurchases(With.Any<PurchaseListingViewModel>()));
    }
}
