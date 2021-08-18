namespace GlassesStore.Test.Controllers.Admin
{
    using GlassesStore.Models;
    using GlassesStore.Web.Areas.Administrator.Controllers;
    using GlassesStore.Web.Areas.Administrator.Models.User;
    using Microsoft.AspNetCore.Identity;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using static Constants.Constants.AdministratorConstants;
    public class UserConrollerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
           => MyController<UserController>
               .Instance()
               .Calling(c => c.All(new UserListingViewModel()))
               .ShouldReturn()
               .View(v => v.WithModelOfType<UserListingViewModel>());

        [Theory]
        [InlineData("id")]
        public void MakeAdminShouldReturnCorrectRedirect(string id)
           => MyController<UserController>
               .Instance(c => c.WithUser(new[] { AdministratorRoleName })
               .WithData(d => d.WithEntities(e => 
               {
                   var role = new IdentityRole { Name = AdministratorRoleName, NormalizedName = AdministratorRoleName.ToUpper() };
                   e.Add(role);

                   var user = new User
                   {
                       Id = id
                   };

                   e.Add(user);
               })))
               .Calling(c => c.MakeAdmin(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
                    .To<UserController>(c => c.All(With.Any<UserListingViewModel>())));

        [Theory]
        [InlineData("id")]
        public void RevokeAdminShouldReturnCorrectRedirect(string id)
           => MyController<UserController>
               .Instance(c => c.WithUser(new[] { AdministratorRoleName })
               .WithData(d => d.WithEntities(e =>
               {
                   var role = new IdentityRole { Name = AdministratorRoleName, NormalizedName = AdministratorRoleName.ToUpper() };
                   e.Add(role);

                   var user = new User
                   {
                       Id = id
                   };

                   e.Add(user);
               })))
               .Calling(c => c.RevokeAdmin(id))
               .ShouldReturn()
               .Redirect(redirect => redirect
                    .To<UserController>(c => c.All(With.Any<UserListingViewModel>())));
    }
}
