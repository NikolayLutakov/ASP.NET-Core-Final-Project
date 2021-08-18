namespace GlassesStore.Test.Routing.Admin
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using GlassesStore.Web.Areas.Administrator.Controllers;
    using GlassesStore.Web.Areas.Administrator.Models.User;

    public class UserControllerTest
    {
        [Fact]
        public void AllShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/User/All")
            .To<UserController>(c => c.All(With.Any<UserListingViewModel>()));

        [Theory]
        [InlineData("userId")]
        public void MakeAdminShouldMapRoute(string id)
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/User/MakeAdmin/userId")
            .To<UserController>(c => c.MakeAdmin(id));

        [Theory]
        [InlineData("userId")]
        public void RevokeAdminShouldMapRoute(string id)
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/User/RevokeAdmin/userId")
            .To<UserController>(c => c.RevokeAdmin(id));
    }
}
