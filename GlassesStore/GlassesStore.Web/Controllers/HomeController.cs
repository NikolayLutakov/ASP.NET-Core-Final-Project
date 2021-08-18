namespace GlassesStore.Controllers
{
    using System.Diagnostics;
    using AutoMapper;
    using GlassesStore.Services.Contacts;
    using GlassesStore.Web.Models;
    using GlassesStore.Web.Models.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using static GlassesStore.Constants.Constants.AdministratorConstants;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IContactService contactService, IMapper mapper)
        {
            _logger = logger;
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Shop");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!contactService.AddMessage(model.Name, model.Email, model.Subject, model.Message))
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Home");
        }   
    }
}
