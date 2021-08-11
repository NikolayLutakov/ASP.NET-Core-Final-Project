using AutoMapper;
using GlassesStore.Services.Glasses;
using GlassesStore.Web.Areas.Administrator.Models.Glasses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            var model = mapper.Map<List<GlassesViewModel>>(glassesService.All());

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


            return RedirectToAction("Index", "Glasses");
        }

        private GlassesFormViewModel PopulateCollections(GlassesFormViewModel model)
        {
            var collections = mapper.Map<GlassesFormViewModel>(glassesService.PopulateBookFormModel());

            model.TypeList = collections.TypeList;
            model.BrandList = collections.BrandList;

            return model;
        }
    }
}
