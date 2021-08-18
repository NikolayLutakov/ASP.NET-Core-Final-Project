namespace GlassesStore.Test.Controllers.Admin
{
    using GlassesStore.Models;
    using GlassesStore.Web.Models.Home;
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using static Constants.Constants.AdministratorConstants;

    public class HomeControllerTest
    {
        [Fact]
        public void AllMessagesShouldReturnView()
          => MyController<Web.Areas.Administrator.Controllers.HomeController>
              .Instance(controller => controller
                  .WithUser(new[] { AdministratorRoleName }))
              .Calling(c => c.AllMessages(new ContactMessagesListingViewModel()))
              .ShouldReturn()
              .View();

        [Theory]
        [InlineData(1)]
        public void MarkMessageReadShouldReturnRedirectToAction(int id)
           => MyController<Web.Areas.Administrator.Controllers.HomeController>
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
                   .To<Web.Areas.Administrator.Controllers.HomeController>(c => c.AllMessages(With.Any<ContactMessagesListingViewModel>())));

        [Theory]
        [InlineData(1)]
        public void MarkMessageUnreadShouldReturnRedirectToAction(int id)
           => MyController<Web.Areas.Administrator.Controllers.HomeController>
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
                   .To<Web.Areas.Administrator.Controllers.HomeController>(c => c.AllMessages(With.Any<ContactMessagesListingViewModel>())));
    }
}
