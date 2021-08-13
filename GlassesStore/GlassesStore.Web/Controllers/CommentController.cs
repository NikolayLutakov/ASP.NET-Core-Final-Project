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

            return RedirectToAction("Details", "Shop", new { id = model.GlassesId });
        }

       
        public IActionResult Edit(int commentId)
        {
            var comment = commentService.GetById(commentId);

            if (comment == null)
            {
                return BadRequest();
            }

            var model = new CommentFormViewModel
            {
                UserId = comment.UserId,
                GlassesId = comment.GlassesId,
                Content = comment.Content,
                Id = comment.Id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CommentFormViewModel model, bool flag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!commentService.Edit(model.Id, model.UserId, model.GlassesId, model.Content))
            {
                return BadRequest();
            }

            if (flag)
            {
                return RedirectToAction("MyComments", "Comment");
            }

            return RedirectToAction("Details", "Shop", new { id = model.GlassesId });
        }

        public IActionResult Delete(int commentId, int productId, bool flag)
        {
            if (!commentService.Delete(commentId, User.Id()))
            {
                return BadRequest();
            }

            if (flag)
            {
                return RedirectToAction("MyComments", "Comment");
            }

            return RedirectToAction("Details", "Shop", new { id = productId });
        }

        public IActionResult MyComments()
        {
            var model = commentService.GetCommentsForUser(User.Id());

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
