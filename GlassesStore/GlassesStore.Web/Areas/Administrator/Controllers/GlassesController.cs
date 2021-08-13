using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GlassesStore.Services.Glasses;
using GlassesStore.Web.Areas.Administrator.Models.Glasses;

namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    public class GlassesController : AdminController
    {
        private readonly IGlassesService glassesService;
        private readonly IMapper mapper;

        public GlassesController(IMapper mapper, IGlassesService glassesService)
        {
            this.mapper = mapper;
            this.glassesService = glassesService;
        }

        public IActionResult Index([FromQuery] AdminGlassesListingViewModel query)
        {
            var model = mapper.Map<AdminGlassesListingViewModel>(glassesService.All(query.CurrentPage, AdminGlassesListingViewModel.GlassesPerPage));

            return View(model);
        }

        public IActionResult Add()
        {           
            return View(PopulateCollections(new GlassesFormViewModel()));
        }

        [HttpPost]
        public IActionResult Add(GlassesFormViewModel model)
        {
            if (!ModelState.IsValid)
            {                
                return View(PopulateCollections(model));
            }

            if (!glassesService.Add(
                model.ModelName,
                model.Description,
                model.Price,
                model.ImageUrl,
                model.BrandId,
                model.TypeId
                ))
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Glasses");
        }

        public IActionResult Edit(int id)
        {
            var model = PopulateCollections(id, new GlassesFormViewModel());

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GlassesFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(PopulateCollections(model.Id, new GlassesFormViewModel()));
            }

            if (model == null)
            {
                return BadRequest();
            }

            if (!glassesService.Edit(
                model.Id,
                model.ModelName,
                model.Description,
                model.Price,
                model.ImageUrl,
                model.BrandId,
                model.TypeId
                ))
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Glasses");
        }

        private GlassesFormViewModel PopulateCollections(int id, GlassesFormViewModel model)
        {
            var collections = mapper.Map<GlassesFormViewModel>(glassesService.PopulateGlassesFormModel(id));

            if (collections == null)
            {
                return null;
            }

            model.Id = collections.Id;
            model.Description = collections.Description;
            model.Price = collections.Price;
            model.ImageUrl = collections.ImageUrl;
            model.ModelName = collections.ModelName;
            model.TypeId = collections.TypeId;
            model.BrandId = collections.BrandId;
            model.TypeList = collections.TypeList;
            model.BrandList = collections.BrandList;

            return model;
        }

        public IActionResult Delete(int id)
        {
            if (!glassesService.Delete(id))
            {
                return BadRequest();
            }
            
            return RedirectToAction("Index", "Glasses");
        }

        private GlassesFormViewModel PopulateCollections(GlassesFormViewModel model)
        {
            var collections = mapper.Map<GlassesFormViewModel>(glassesService.PopulateGlassesFormModel());

            model.TypeList = collections.TypeList;
            model.BrandList = collections.BrandList;

            return model;
        }
    }
}
