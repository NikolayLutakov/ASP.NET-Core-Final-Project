﻿using AutoMapper;
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
            var result = PopulateCollections(id, new GlassesFormViewModel());

            if (result == null)
            {
                return BadRequest();
            }

            return View(result);
        }

        private GlassesFormViewModel PopulateCollections(int id, GlassesFormViewModel model)
        {
            var collections = mapper.Map<GlassesFormViewModel>(glassesService.PopulateBookFormModel(id));

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
        private GlassesFormViewModel PopulateCollections(GlassesFormViewModel model)
        {
            var collections = mapper.Map<GlassesFormViewModel>(glassesService.PopulateBookFormModel());

            model.TypeList = collections.TypeList;
            model.BrandList = collections.BrandList;

            return model;
        }
    }
}
