namespace GlassesStore.Test.Controllers
{
    using GlassesStore.Controllers;
    using GlassesStore.Models;
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Home;
    using GlassesStore.Web.Models.Shop;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using static Constants.Constants.AdministratorConstants;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View();

        [Fact]
        public void IndexShouldRedirectCorrectActionWithModel()
            => MyController<HomeController>
                .Instance(controller => controller
                    .WithUser())
                .Calling(c => c.Index())
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<ShopController>(c => c.Index(With.Any<GlassesListingViewModel>())));

        [Fact]
        public void ErrorShouldReturnView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Error())
                .ShouldReturn()
                .View();

        [Fact]
        public void ContactsShouldReturnCorrectViewWithModel()
           => MyController<HomeController>
               .Instance()
               .Calling(c => c.Contacts())
               .ShouldReturn()
               .View();

        [Theory]
        [InlineData("name", "email@email", "subject", "message")]
        public void PostContactsShouldReturnCorrectViewWithModel(
            string name,
            string email,
            string subject,
            string message)
           => MyController<HomeController>
               .Instance()
               .Calling(c => c.Contacts(new ContactFormViewModel
               {
                   Name = name,
                   Email = email,
                   Subject = subject,
                   Message = message
               }))
            .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForHttpMethod(HttpMethod.Post))
                .ValidModelState()
            .AndAlso()
            .ShouldReturn()
               .Redirect(redirect => redirect
                   .To<HomeController>(c => c.Index()));

        [Fact]
        public void AllMessagesShouldReturnView()
            => MyController<HomeController>
                .Instance(controller => controller
                    .WithUser(new[] { AdministratorRoleName }))
                .Calling(c => c.AllMessages(new ContactMessagesListingViewModel()))
                .ShouldReturn()
                .View();

        [Theory]
        [InlineData(1)]
        public void MarkMessageReadShouldReturnRedirectToAction(int id)
           => MyController<HomeController>
               .Instance(controller => controller
                   .WithUser(new[] { AdministratorRoleName })
               .WithData(data => data
               .WithEntities(entities =>
               {
                   var contactMessage = new ContactMessage
                   {
                       Id = id
                   };
                   entities.Add(contactMessage);
               })))
               .Calling(c => c.MarkMessageRead(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
                   .To<HomeController>(c => c.AllMessages(With.Any<ContactMessagesListingViewModel>())));

        [Theory]
        [InlineData(1)]
        public void MarkMessageUnreadShouldReturnRedirectToAction(int id)
           => MyController<HomeController>
               .Instance(controller => controller
                   .WithUser(new[] { AdministratorRoleName })
               .WithData(data => data
               .WithEntities(entities =>
               {
                   var contactMessage = new ContactMessage
                   {
                       Id = id
                   };
                   entities.Add(contactMessage);
               })))
               .Calling(c => c.MarkMessageUnread(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
                   .To<HomeController>(c => c.AllMessages(With.Any<ContactMessagesListingViewModel>())));
    }
}
