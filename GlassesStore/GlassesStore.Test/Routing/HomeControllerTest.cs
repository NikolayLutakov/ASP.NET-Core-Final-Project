namespace GlassesStore.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using GlassesStore.Controllers;
    using GlassesStore.Web.Models.Home;

    public class HomeControllerTest
    {
        [Fact]
        public void AdministratorIndexRouteShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Administrator/")
               .To<Web.Areas.Administrator.Controllers.HomeController>(c => c.Index());

        [Fact]
        public void IndexRouteShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/")
               .To<HomeController>(c => c.Index());

        [Fact]
        public void ErrorRouteShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Home/Error")
               .To<HomeController>(c => c.Error());

        [Fact]
        public void ContactsRouteShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap("/Home/Contacts")
              .To<HomeController>(c => c.Contacts());

        [Fact]
        public void PostContactsRouteShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap(request => request
              .WithPath("/Home/Contacts")
              .WithMethod(HttpMethod.Post))
              .To<HomeController>(c => c.Contacts(With.Any<ContactFormViewModel>()));

        [Fact]
        public void AllMessagesRouteShouldBeMapped()
         => MyRouting
             .Configuration()
             .ShouldMap("/Home/AllMessages")
             .To<HomeController>(c => c.AllMessages(new ContactMessagesListingViewModel()));

        [Theory]
        [InlineData(1)]
        public void MarkMessageReadRouteShouldBeMapped(int messageId)
         => MyRouting
             .Configuration()
             .ShouldMap("/Home/MarkMessageRead?messageId=1")
             .To<HomeController>(c => c.MarkMessageRead(messageId));

        [Theory]
        [InlineData(1)]
        public void MarkMessageUnreadRouteShouldBeMapped(int messageId)
         => MyRouting
             .Configuration()
             .ShouldMap("/Home/MarkMessageUnread?messageId=1")
             .To<HomeController>(c => c.MarkMessageUnread(messageId));
    }
}
