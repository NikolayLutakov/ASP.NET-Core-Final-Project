using AutoMapper;
using GlassesStore.Services.Brand;
using GlassesStore.Web.Areas.Administrator.Models.Brand;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    public class BrandController : AdminController
    {
        private readonly IBrandService brandService;
        private readonly IMapper mapper;

        public BrandController(IMapper mapper, IBrandService brandService)
        {
            this.mapper = mapper;
            this.brandService = brandService;
        }
        public IActionResult Index()
        {
            var model = mapper.Map<List<BrandViewModel>>(brandService.All());

            return View(model);
        }

    }
}
