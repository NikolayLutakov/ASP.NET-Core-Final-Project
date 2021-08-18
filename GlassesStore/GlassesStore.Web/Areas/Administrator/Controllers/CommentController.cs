namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    using AutoMapper;
    using GlassesStore.Services.Comment;
    using GlassesStore.Web.Models.Comment;
    using Microsoft.AspNetCore.Mvc;
    public class CommentController : AdminController
    {
        private readonly IMapper mapper;
        private readonly ICommentService commentService;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            this.mapper = mapper;
            this.commentService = commentService;
        }

        public IActionResult AllComments([FromQuery] CommentListingViewModel query)
        {
            var model = mapper
                  .Map<CommentListingViewModel>(commentService
                                              .All(query.CurrentPage, CommentListingViewModel.CommentsPerPage));

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
