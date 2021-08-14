namespace GlassesStore.Web.Controllers
{
    using AutoMapper;
    using GlassesStore.Services.Card;
    using GlassesStore.Web.Infrastructure.Extensions;
    using GlassesStore.Web.Models.Card;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Authorize]
    public class CardController : Controller
    {
        private readonly ICardService cardService;
        private readonly IMapper mapper;

        public CardController(ICardService cardService, IMapper mapper)
        {
            this.cardService = cardService;
            this.mapper = mapper;
        }

        public IActionResult Index([FromQuery] CardListingViewModel query)
        {
            var model = mapper
                .Map<CardListingViewModel>(cardService
                                            .ListAllCardsForUser(
                                                                query.CurrentPage, 
                                                                CardListingViewModel
                                                                    .CardsPerPage, 
                                                                User.Id()));

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        public IActionResult Add()
        {
            var model = new CardFormViewModel()
            {
                TypesList = cardService.GetCardTypes()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CardFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TypesList = cardService.GetCardTypes();

                return View(model);
            }

            if (!cardService.Add(model.Number, model.ExpiresOn, User.Id(), model.TypeId))
            {
                return BadRequest();
            }
            
            return RedirectToAction("Index", "Card");
        }

        public IActionResult Edit(int cardId)
        {
            var card = cardService.GetById(cardId);

            var model = new CardFormViewModel
            {
                Id = card.Id,
                ExpiresOn = DateTime.Parse(card.ExpiresOn),
                Number = card.Number,
                TypeId = card.TypeId,
                TypesList = cardService.GetCardTypes()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CardFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TypesList = cardService.GetCardTypes();

                return View(model);
            }

            if (!cardService.Edit(model.Id, model.Number, model.ExpiresOn, User.Id(), model.TypeId))
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Card");
        }
    }
}
