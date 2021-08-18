namespace GlassesStore.Test.Controllers
{
    using GlassesStore.Models;
    using GlassesStore.Web.Controllers;
    using GlassesStore.Web.Models.Comment;
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    public class CommentControllerTest
    {
        [Theory]
        [InlineData(1)]
        public void AddShouldReturnViewWithModel(int commentId)
           => MyController<CommentController>
               .Instance(c => c.WithUser())
               .Calling(c => c.Add(commentId))
               .ShouldReturn()
               .View((view => view
                   .WithModelOfType<CommentFormViewModel>()));

        [Theory]
        [InlineData(1, 1, 1, "model", "brandName", "desctription", "typeName", "content")]
        public void PostAddShouldReturnRedirectToDetailsShopAction(
            int productId,
            int typeId,
            int brandId,
            string model,
            string brandName,
            string desc,
            string typeName,
            string content)
            => MyController<CommentController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(entities =>
                        {
                            var glasses = new Glasses
                            {
                                Id = productId,
                                ImageUrl = "/",
                                Model = model,
                                Brand = new Brand
                                {
                                    Id = brandId,
                                    Name = brandName
                                },
                                Description = desc,
                                Type = new GlassesType
                                {
                                    Id = typeId,
                                    Name = typeName
                                }

                            };
                            entities.Add(glasses);
                        })))
                .Calling(c => c.Add(new CommentFormViewModel()
                {
                    Content = content,
                    GlassesId = productId
                }))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<ShopController>(c => c.Details(productId)));

        [Theory]
        [InlineData(1)]
        public void EditShouldReturnViewWithModel(int commentId)
          => MyController<CommentController>
              .Instance(c => c.WithUser().WithData(data => data
                        .WithEntities(entities =>
                        {
                            var comment = new Comment
                            {
                                Id = commentId,
                            };
                            entities.Add(comment);
                        })))
              .Calling(c => c.Edit(commentId))
              .ShouldReturn()
              .View((view => view
                  .WithModelOfType<CommentFormViewModel>()));

        [Theory]
        [InlineData(1, 1, 1, 1, "model", "brandName", "desctription", "typeName", "content")]
        public void PostEditShouldReturnRedirectToDetailsShopAction(
            int commentId,
            int productId,
            int typeId,
            int brandId,
            string model,
            string brandName,
            string desc,
            string typeName,
            string content)
            => MyController<CommentController>
                .Instance(c => c.WithUser()
                    .WithData(data => data
                        .WithEntities(entities =>
                        {
                            var glasses = new Glasses
                            {
                                Id = productId,
                                ImageUrl = "/",
                                Model = model,
                                Brand = new Brand
                                {
                                    Id = brandId,
                                    Name = brandName
                                },
                                Description = desc,
                                Type = new GlassesType
                                {
                                    Id = typeId,
                                    Name = typeName
                                }
                            };
                            entities.Add(glasses);

                            var comment = new Comment
                            {
                                Id = commentId,
                                GlassesId = productId
                            };

                            entities.Add(comment);
                        })))
                .Calling(c => c.Edit(new CommentFormViewModel()
                { 
                    Id = commentId,
                    Content = content,
                    GlassesId = productId
                }, null))
            .ShouldHave()
            .ActionAttributes(attrs => attrs
                    .RestrictingForHttpMethod(HttpMethod.Post))
            .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<Web.Areas.Administrator.Controllers.CommentController>(c => c.AllComments(With.Any<CommentListingViewModel>())));

        [Theory]
        [InlineData(1, 1, "username", "id")]
        public void DeleteShouldRedirectToMyComments(int commentId, int productId, string userName, string userId)
          => MyController<CommentController>
              .Instance(c => c.WithUser(userId, userName)
                .WithData(data => data
                        .WithEntities(entities =>
                        {
                            var user = new User
                            {
                                Id = userId,
                                Email = userName,
                                UserName = userName,
                                NormalizedUserName = userName,
                                NormalizedEmail = userName
                            };

                            entities.Add(user);

                            var comment = new Comment
                            {
                                Id = commentId,
                                UserId = userId,
                                GlassesId = productId
                            };
                            entities.Add(comment);
                        })))
              .Calling(c => c.Delete(commentId, 1, null))
              .ShouldReturn()
              .Redirect(redirect => redirect
                    .To<CommentController>(c => c.MyComments(With.Any<CommentListingViewModel>())));

        [Fact]
        public void MyCommentsShouldReturnViewWithModel()
          => MyController<CommentController>
              .Instance(c => c.WithUser())
              .Calling(c => c.MyComments(new CommentListingViewModel()))
              .ShouldReturn()
              .View(view => view
                  .WithModelOfType<CommentListingViewModel>());
    }
}
