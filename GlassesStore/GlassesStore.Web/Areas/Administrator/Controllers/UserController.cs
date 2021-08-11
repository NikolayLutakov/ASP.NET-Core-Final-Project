using AutoMapper;
using GlassesStore.Services.Users;
using GlassesStore.Web.Areas.Administrator.Models;
using GlassesStore.Web.Areas.Administrator.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult All()
        {
            var users = userService.All();

            var model = mapper.Map<List<UserViewModel>>(users);

            return View(model);
        }

        [HttpGet]
        public IActionResult MakeAdmin(string id)
        {
            var result = userService.MakeAdmin(id);

            if (!result)
            {
                return BadRequest();
            }

            return RedirectToAction("All", "User");
        }

        public IActionResult RevokeAdmin(string id)
        {
            if (this.User.FindFirstValue(ClaimTypes.NameIdentifier) == id)
            {
                return BadRequest();
            }

            var result = userService.RevokeAdmin(id);

            if (!result)
            {
                return BadRequest();
            }

            return RedirectToAction("All", "User");
        }
    }
}
