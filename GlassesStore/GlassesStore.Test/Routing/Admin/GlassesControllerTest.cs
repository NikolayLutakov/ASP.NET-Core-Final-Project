namespace GlassesStore.Test.Routing.Admin
{
    using Xunit;
    using MyTested.AspNetCore.Mvc;
    using GlassesStore.Web.Areas.Administrator.Controllers;
    using GlassesStore.Web.Areas.Administrator.Models.Glasses;

    public class GlassesControllerTest
    {
        [Fact]
        public void IndexShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/Glasses/")
            .To<GlassesController>(c => c.Index(With.Any<AdminGlassesListingViewModel>()));

        [Fact]
        public void AddShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/Glasses/Add")
            .To<GlassesController>(c => c.Add(With.Any<GlassesFormViewModel>()));

        [Fact]
        public void PostAddShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
                .WithPath("/Administrator/Glasses/Add")
                .WithMethod(HttpMethod.Post))
            .To<GlassesController>(c => c.Add(With.Any<GlassesFormViewModel>()));

        [Theory]
        [InlineData(1)]
        public void EditShouldMapRoute(int id)
            => MyRouting
            .Configuration()
            .ShouldMap("/Administrator/Glasses/Edit/1")
            .To<GlassesController>(c => c.Edit(id));

        [Fact]
        public void PostEditShouldMapRoute()
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
                .WithPath("/Administrator/Glasses/Edit")
                .WithMethod(HttpMethod.Post))
            .To<GlassesController>(c => c.Edit(With.Any<GlassesFormViewModel>()));

        [Theory]
        [InlineData(1)]
        public void DeleteShouldMapRoute(int id)
            => MyRouting
            .Configuration()
            .ShouldMap(request => request
                .WithPath("/Administrator/Glasses/Delete/1")
                .WithMethod(HttpMethod.Post))
            .To<GlassesController>(c => c.Delete(id));
    }
}
