namespace GlassesStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GlassesStore.Services.Glasses;
    using AutoMapper;
    using GlassesStore.Web.Models.Shop;
    using System.Collections.Generic;
    using System.Linq;
    using GlassesStore.Services.Users;
    using GlassesStore.Web.Infrastructure.Extensions;
    using GlassesStore.Services.Card;

    [Authorize]
    public class ShopController : Controller
    {
        private readonly IGlassesService glassesService;
        private readonly IMapper mapper;
        private readonly ICardService cardService;

        public ShopController(IGlassesService glassesService, IMapper mapper, ICardService cardService)
        {
            this.glassesService = glassesService;
            this.mapper = mapper;
            this.cardService = cardService;
        }

        public IActionResult Index([FromQuery] GlassesListingViewModel query)
        {
            var result = mapper
                .Map<GlassesListingViewModel>(glassesService.Search(query.SearchTerm, query.CurrentPage, GlassesListingViewModel.GlassesPerPage));
            
            query.Glasses = result.Glasses;
            query.TotalGlasses = result.TotalGlasses;
            
            return View(query);
        }

        public IActionResult Details(int id)
        {
            var glasses = mapper.Map<GlassesDetailsViewModel>(glassesService.GetById(id));

            return View(glasses);
        }

        public IActionResult Buy(int id)
        {
            var userId = User.Id();

            var product = glassesService.GetById(id);
            var userCards = cardService.GetCardsForUser(userId);

            var model = new PurchaseViewModel()
            {
                ProductToBuy = product,
                UserCards = userCards
            };


            return View(model);
        }
    }
}
