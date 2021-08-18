namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    using AutoMapper;
    using GlassesStore.Services.Contacts;
    using GlassesStore.Web.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using static Constants.Constants.AdministratorConstants;
    public class HomeController : AdminController
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public HomeController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

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
        
        public IActionResult MarkMessageRead(int messageId)
        {
            if (!contactService.MarkRead(messageId))
            {
                return BadRequest();
            }

            return RedirectToAction("AllMessages", "Home", new { area = AdministratorAreaName });
        }

        public IActionResult MarkMessageUnread(int messageId)
        {
            if (!contactService.MarkUnread(messageId))
            {
                return BadRequest();
            }

            return RedirectToAction("AllMessages", "Home", new { area = AdministratorAreaName});
        }
    }
}
