namespace GlassesStore.Web.Controllers
{
    using GlassesStore.Services.Comment;
    using GlassesStore.Web.Infrastructure.Extensions;
    using GlassesStore.Web.Models.Comment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IActionResult Add(int id)
        {
            var model = new CommentFormViewModel
            {
                UserId = User.Id(),
                GlassesId = id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CommentFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!commentService.Add(model.UserId, model.GlassesId, model.Content))
            {
                return BadRequest();
            }

            return RedirectToAction("Details", "Shop", new { model.Id });
        }
    }
}
