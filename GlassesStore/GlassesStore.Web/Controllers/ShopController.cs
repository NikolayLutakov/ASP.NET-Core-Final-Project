namespace GlassesStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using GlassesStore.Services.Glasses;
    using AutoMapper;
    using GlassesStore.Web.Models.Shop;
    using System.Linq;
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
                .Map<GlassesListingViewModel>(glassesService.Search(query.SearchTerm, query.CurrentPage, GlassesListingViewModel.GlassesPerPage, query.FilterByType, query.OrderBy));
            
            query.Glasses = result.Glasses;
            query.TotalGlasses = result.TotalGlasses;
            query.GlassesTypes = result.GlassesTypes;

            return View(query);
        }

        public IActionResult Details(int id)
        {
            var glasses = mapper.Map<GlassesDetailsViewModel>(glassesService.GetById(id));

            if (glasses == null)
            {
                return BadRequest();
            }

            return View(glasses);
        }

        public IActionResult Buy(int id)
        {
            var model = new PurchaseViewModel()
            {
                ProductToBuy = glassesService.GetById(id),
                UserCards = cardService.GetCardsForUser(User.Id())
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Buy(PurchaseViewModel model)
        {
            var userCardIds = cardService
                .GetCardsForUser(User.Id())
                .Select(x => x.Id)
                .ToList();

            if (!userCardIds.Contains(model.CardId))
            {
                return BadRequest();
            }

            if (!cardService.MakePurchase(model.CardId, model.ProductId, model.Price))
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Shop");
        }

        public IActionResult MyPurchases([FromQuery] PurchaseListingViewModel query)
        {

            var model = mapper
                .Map<PurchaseListingViewModel>(cardService.MyPurchases(
                                                                query.CurrentPage,
                                                                PurchaseListingViewModel
                                                                    .PurchasesPerPage,
                                                                User.Id()));

            return View(model);
        }
    }
}
