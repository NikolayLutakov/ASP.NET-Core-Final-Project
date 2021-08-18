namespace GlassesStore.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using GlassesStore.Controllers;
    using GlassesStore.Web.Models.Home;

    public class HomeControllerTest
    { 
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
    }
}
