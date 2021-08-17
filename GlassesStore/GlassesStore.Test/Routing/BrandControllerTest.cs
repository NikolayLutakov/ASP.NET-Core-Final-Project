namespace GlassesStore.Test.Routing
{
    using GlassesStore.Web.Areas.Administrator.Controllers;
    using GlassesStore.Web.Areas.Administrator.Models.Brand;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class BrandControllerTest
    {
        [Fact]
        public void IndexShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/Brand/")
            .To<BrandController>(c => c.Index(With.Any<BrandListingViewModel>()));

        [Fact]
        public void AddShouldMapRoute()
           => MyRouting
           .Configuration()
           .ShouldMap("/Administrator/Brand/Add")
           .To<BrandController>(c => c.Add(With.Any<BrandFormViewModel>()));

        [Fact]
        public void PostAddShouldMapRoute()
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Administrator/Brand/Add")
            .WithMethod(HttpMethod.Post))
          .To<BrandController>(c => c.Add(With.Any<BrandFormViewModel>()));

        [Theory]
        [InlineData(1)]
        public void EditShouldMapRoute(int id)
          => MyRouting
          .Configuration()
          .ShouldMap("/Administrator/Brand/Edit/1")
          .To<BrandController>(c => c.Edit(id));

        [Fact]
        public void PostEditShouldMapRoute()
          => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Administrator/Brand/Edit")
            .WithMethod(HttpMethod.Post))
          .To<BrandController>(c => c.Edit(With.Any<BrandFormViewModel>()));

        [Theory]
        [InlineData(1)]
        public void DeleteShouldMapRoute(int id)
          => MyRouting
          .Configuration()
          .ShouldMap("/Administrator/Brand/Delete/1")
          .To<BrandController>(c => c.Delete(id));

    }
}
