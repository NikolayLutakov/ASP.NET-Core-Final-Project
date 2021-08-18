namespace GlassesStore.Test.Controllers.Admin
{
    using GlassesStore.Models;
    using GlassesStore.Web.Areas.Administrator.Controllers;
    using GlassesStore.Web.Areas.Administrator.Models.Brand;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class BrandControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
            => MyController<BrandController>
                .Instance()
                .Calling(c => c.Index(new BrandListingViewModel()))
                .ShouldReturn()
                .View(v => v.WithModelOfType<BrandListingViewModel>());

        [Fact]
        public void AddShouldReturnCorrectView()
            => MyController<BrandController>
                .Instance()
                .Calling(c => c.Add())
                .ShouldReturn()
                .View();

        [Theory]
        [InlineData("name", "description")]
        public void PostAddShouldReturnRedirectToIndexAction(string name, string description)
            => MyController<BrandController>
                .Instance()
                .Calling(c => c.Add(new BrandFormViewModel()
                {
                    Name = name,
                    Description = description
                }))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<BrandController>(c => c.Index(With.Any<BrandListingViewModel>())));

        [Theory]
        [InlineData(1, "name", "description")]
        public void EditShouldReturnCorrectView(int id, string name, string description)
           => MyController<BrandController>
               .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(e =>
                        {
                            var brand = new Brand()
                            {
                                Id = id,
                                Name = name,
                                Description = description
                            };

                            e.Add(brand);
                        })))
               .Calling(c => c.Edit(id))
               .ShouldReturn()
               .View(v => v.WithModelOfType<BrandFormViewModel>());
              

        [Theory]
        [InlineData(1, "name", "description")]
        public void PostEditShouldReturnRedirectToIndexAction(int id, string name, string description)
            => MyController<BrandController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(e => 
                        {
                            var brand = new Brand()
                            {
                                Id = id,
                                Name = name,
                                Description = description
                            };

                            e.Add(brand);
                        })))
                .Calling(c => c.Edit(new BrandFormViewModel()
                {
                    Id = id,
                    Name = name,
                    Description = description
                }))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<BrandController>(c => c.Index(With.Any<BrandListingViewModel>())));

        [Theory]
        [InlineData(1, "name", "description")]
        public void DeleteShouldReturnRedirectToIndexAction(int id, string name, string description)
            => MyController<BrandController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(e =>
                        {
                            var brand = new Brand()
                            {
                                Id = id,
                                Name = name,
                                Description = description
                            };

                            e.Add(brand);
                        })))
                .Calling(c => c.Delete(id))
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<BrandController>(c => c.Index(With.Any<BrandListingViewModel>())));

    }
}
