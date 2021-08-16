using AutoMapper;
using GlassesStore.Services.Glasses;
using GlassesStore.Services.Glasses.Models;
using GlassesStore.Services.Like;
using GlassesStore.Services.Like.Models;
using GlassesStore.Web.Infrastructure.Extensions;
using GlassesStore.Web.Models.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Controllers
{
    [Authorize]
    public class LikeController : Controller
    {
        private readonly ILikeService likeService;
        private readonly IGlassesService glassesService;
        private readonly IMapper mapper;

        public LikeController(ILikeService likeService, IGlassesService glassesService, IMapper mapper)
        {
            this.likeService = likeService;
            this.glassesService = glassesService;
            this.mapper = mapper;
        }

        public IActionResult Like(int productId, string callerView, [FromQuery]GlassesListingViewModel model)
        {

            if (!likeService.Like(productId, User.Id()))
            {
                return BadRequest();
            }


            if (callerView == "details")
            {
                return RedirectToAction("Details", "Shop", new { id = productId });
            }
            else 
            {
                return RedirectToAction("MyLikes", "Like");
            }
            
        }

        public IActionResult Unlike(int productId, string callerView)
        {
            if (!likeService.Unlike(productId, User.Id()))
            {
                return BadRequest();
            }

            if (callerView == "details")
            {
                return RedirectToAction("Details", "Shop", new { id = productId });
            }
            else if (callerView == "index")
            {
                return RedirectToAction("Index", "Shop");
            }
            else
            {
                return RedirectToAction("MyLikes", "Like");
            }
        }

        public IActionResult MyLikes([FromQuery] GlassesListingViewModel query)
        {
            var likes = likeService.GetLikesForUser(User.Id()).Select(x => x.GlassesId);

            var model = mapper
                .Map<GlassesListingViewModel>(glassesService.AllGlassesForLikes(query.CurrentPage, GlassesListingViewModel.GlassesPerPage, likes));


            return View(model);
        }
    }
}
