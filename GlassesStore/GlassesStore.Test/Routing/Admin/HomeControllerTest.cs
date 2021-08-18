namespace GlassesStore.Test.Routing.Admin
{
    using GlassesStore.Web.Models.Home;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using Web.Areas.Administrator.Controllers;

    public class HomeControllerTest
    {
        [Fact]
        public void AdministratorIndexRouteShouldBeMapped()
           => MyRouting
               .Configuration()
               .ShouldMap("/Administrator/")
               .To<HomeController>(c => c.Index());

        [Fact]
        public void AllMessagesRouteShouldBeMapped()
        => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/Home/AllMessages")
            .To<HomeController>(c => c.AllMessages(new ContactMessagesListingViewModel()));

        [Theory]
        [InlineData(1)]
        public void MarkMessageReadRouteShouldBeMapped(int messageId)
         => MyRouting
             .Configuration()
             .ShouldMap("/Administrator/Home/MarkMessageRead?messageId=1")
             .To<HomeController>(c => c.MarkMessageRead(messageId));

        [Theory]
        [InlineData(1)]
        public void MarkMessageUnreadRouteShouldBeMapped(int messageId)
         => MyRouting
             .Configuration()
             .ShouldMap("/Administrator/Home/MarkMessageUnread?messageId=1")
             .To<HomeController>(c => c.MarkMessageUnread(messageId));
    }
}
