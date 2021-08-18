namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    using AutoMapper;
    using GlassesStore.Services.Users;
    using GlassesStore.Web.Areas.Administrator.Models.User;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using static Constants.Constants;
    using static Constants.Constants.AdministratorConstants;

    public class UserController : AdminController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

  
        public IActionResult All([FromQuery] UserListingViewModel query)
        {
            var model = mapper.Map<UserListingViewModel>(userService.All(query.CurrentPage, UserListingViewModel.UsersPerPage));

            return View(model);
        }

  
        public IActionResult MakeAdmin(string id)
        {
            var result = userService.MakeAdmin(id);

            if (!result)
            {
                return BadRequest();
            }

            TempData[UpdateGlobalKey] = "Administrator added succesfuly.";
            return RedirectToAction("All", "User", new { area = AdministratorRoleName });
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

            TempData[DeleteGlobalKey] = "Administrator removed succesfuly.";
            return RedirectToAction("All", "User", new { area = AdministratorRoleName });
        }
    }
}
