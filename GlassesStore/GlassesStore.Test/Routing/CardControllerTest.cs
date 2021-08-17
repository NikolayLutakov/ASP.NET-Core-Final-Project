namespace GlassesStore.Test.Routing
{
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Card;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class CardControllerTest
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap("/Card/Index")
              .To<CardController>(c => c.Index(new CardListingViewModel()));

        [Theory]
        [InlineData(true, 1)]
        public void AddRouteShouldBeMapped(bool flag, int productId)
         => MyRouting
             .Configuration()
             .ShouldMap("/Card/Add?flag=true&productId=1")
             .To<CardController>(c => c.Add(flag, productId));

        [Fact]
        public void PostAddRouteShouldBeMapped()
        => MyRouting
            .Configuration()
           .ShouldMap(request => request
                   .WithPath("/Card/Add")
                   .WithMethod(HttpMethod.Post))
            .To<CardController>(c => c.Add(With.Any<CardFormViewModel>()));

        [Theory]
        [InlineData(1)]
        public void EditRouteShouldBeMapped(int cardId)
         => MyRouting
             .Configuration()
             .ShouldMap("/Card/Edit?cardId=1")
             .To<CardController>(c => c.Edit(cardId));

        
        [Fact]
        public void PostEditRouteShouldBeMapped()
         => MyRouting
             .Configuration()
            .ShouldMap(request => request
                    .WithPath("/Card/Edit")
                    .WithMethod(HttpMethod.Post))
             .To<CardController>(c => c.Edit(With.Any<CardFormViewModel>()));
    }
}
