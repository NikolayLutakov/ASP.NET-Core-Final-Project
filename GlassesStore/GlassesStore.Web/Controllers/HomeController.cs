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
    using static GlassesStore.Models.Common.Constants.AdministratorConstants;
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


        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult AllMessages([FromQuery] ContactMessagesListingViewModel query)
        {
            var model = mapper
                 .Map<ContactMessagesListingViewModel>(contactService
                                             .All(query.CurrentPage, ContactMessagesListingViewModel.MessagesPerPage));

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult MarkMessageRead(int messageId)
        {
            if (!contactService.MarkRead(messageId))
            {
                return BadRequest();
            }

            return RedirectToAction("AllMessages", "Home");
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult MarkMessageUnread(int messageId)
        {
            if (!contactService.MarkUnread(messageId))
            {
                return BadRequest();
            }

            return RedirectToAction("AllMessages", "Home");
        }
    }
}
