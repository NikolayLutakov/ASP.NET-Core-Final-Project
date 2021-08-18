namespace GlassesStore.Test.Controllers
{
    using GlassesStore.Models;
    using GlassesStore.Services.Card.Models;
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Card;
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using Xunit;
    public class CardControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
            => MyController<CardController>
                .Instance(c => c.WithUser())
                .Calling(c => c.Index(new CardListingViewModel()))
                .ShouldReturn()
                .View(new CardListingViewModel() 
                {
                    Cards = new List<CardServiceModel>(),
                    CurrentPage = 1,
                    TotalCards = 0
                });


        [Theory]
        [InlineData(false, 1)]
        public void AddShouldReturnViewWithModel(bool flag, int productId)
            => MyController<CardController>
                .Instance(c => c.WithUser())
                .Calling(c => c.Add(flag, productId))
                .ShouldReturn()
                .View((view => view
                    .WithModelOfType<CardFormViewModel>()));

        [Theory]
        [InlineData(1, 1, "name", "1234567891111111", false)]
        public void PostAddShouldReturnRedirectToIndexCardAction(
            int productId, 
            int typeId, 
            string typeName,
            string cardNumber,
            bool flag)
            => MyController<CardController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(entities =>
                         {
                            var cardType = new CardType
                             {
                                    Id = typeId,
                                    TypeName = typeName
                            };
                            entities.Add(cardType);
                         })))
                .Calling(c => c.Add(new CardFormViewModel() 
                {
                    ExpiresOn = DateTime.UtcNow,
                    Flag = flag,
                    Number = cardNumber,
                    ProductId = productId,
                    TypeId = typeId,
                    TypesList = null
                }))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<CardController>(c => c.Index(With.Any<CardListingViewModel>())));

        [Theory]
        [InlineData(1, 1, "name", "1234567891111111", true)]
        public void PostAddShouldReturnRedirectToBuyShopAction(
            int productId,
            int typeId,
            string typeName,
            string cardNumber,
            bool flag)
            => MyController<CardController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(entities =>
                        {
                            var cardType = new CardType
                            {
                                Id = typeId,
                                TypeName = typeName
                            };
                            entities.Add(cardType);
                        })))
                .Calling(c => c.Add(new CardFormViewModel()
                {
                    ExpiresOn = DateTime.UtcNow,
                    Flag = flag,
                    Number = cardNumber,
                    ProductId = productId,
                    TypeId = typeId,
                    TypesList = null
                }))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<ShopController>(c => c.Buy(productId)));

        [Theory]
        [InlineData(1, "1234567891111111", 1, "name")]
        public void EditShouldReturnViewWithModel(
            int cardId, 
            string cardNumber, 
            int typeId, 
            string typeName)
           => MyController<CardController>
               .Instance(c => c.WithUser()
               .WithData(data => data
                        .WithEntities(entities =>
                        {
                            var card = new Card
                            {
                                Id = cardId,
                                Number = cardNumber,
                                Type = new CardType 
                                { 
                                    Id = typeId,
                                    TypeName = typeName
                                }
                            };
                            entities.Add(card);
                        })))
               .Calling(c => c.Edit(cardId))
               .ShouldReturn()
               .View((view => view
                   .WithModelOfType<CardFormViewModel>()));

        [Theory]
        [InlineData(1, 1, "name", "1234567891111111", false)]
        public void PostEditShouldReturnRedirectToIndexCardAction(
            int productId,
            int typeId,
            string typeName,
            string cardNumber,
            bool flag)
            => MyController<CardController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(entities =>
                        {
                            var cardType = new CardType
                            {
                                Id = typeId,
                                TypeName = typeName
                            };
                            entities.Add(cardType);
                        })))
                .Calling(c => c.Add(new CardFormViewModel()
                {
                    ExpiresOn = DateTime.UtcNow,
                    Flag = flag,
                    Number = cardNumber,
                    ProductId = productId,
                    TypeId = typeId,
                    TypesList = null
                }))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<CardController>(c => c.Index(With.Any<CardListingViewModel>())));

      
    }
}
