namespace GlassesStore.Web.Controllers
{
    using AutoMapper;
    using GlassesStore.Services.Comment;
    using GlassesStore.Web.Infrastructure.Extensions;
    using GlassesStore.Web.Models.Comment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static GlassesStore.Constants.Constants;
    using static GlassesStore.Constants.Constants.AdministratorConstants;
    
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this.commentService = commentService;
            this.mapper = mapper;
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
                return View(model);
            }

            if (!commentService.Add(model.UserId, model.GlassesId, model.Content))
            {
                return BadRequest();
            }

            TempData[CreateGlobalKey] = "Comment created successfuly.";
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
        public IActionResult Edit(CommentFormViewModel model, string callerView)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!commentService.Edit(model.Id, model.UserId, model.GlassesId, model.Content))
            {
                return BadRequest();
            }

            TempData[UpdateGlobalKey] = "Comment edited successfuly.";
            if (callerView == "myComments")
            {
                return RedirectToAction("MyComments", "Comment");
            }
            else if (callerView == "details")
            {
                return RedirectToAction("Details", "Shop", new { id = model.GlassesId });
            }
            else
            {
                return RedirectToAction("AllComments", "Comment", new { area = AdministratorAreaName });
            }
        }

        public IActionResult Delete(int commentId, int productId, string callerView)
        {
            if (!commentService.Delete(commentId, User.Id()))
            {
                return BadRequest();
            }


            TempData[DeleteGlobalKey] = "Comment deleted successfuly.";
            if (callerView == "allComments")
            {
                return RedirectToAction("AllComments", "Comment", new { area = AdministratorAreaName });
            }
            else if (callerView == "details") 
            {
                return RedirectToAction("Details", "Shop", new { id = productId });
            }
            else
            {
                return RedirectToAction("MyComments", "Comment");             
            }

            
        }

        public IActionResult MyComments([FromQuery] CommentListingViewModel query)
        {
            var model = mapper
                 .Map<CommentListingViewModel>(commentService
                                             .GetCommentsForUser(
                                                                 query.CurrentPage,
                                                                 CommentListingViewModel
                                                                     .CommentsPerPage,
                                                                 User.Id()));

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }      
    }
}
