namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    using AutoMapper;
    using GlassesStore.Services.Brand;
    using GlassesStore.Web.Areas.Administrator.Models.Brand;
    using Microsoft.AspNetCore.Mvc;
    using static Constants.Constants;
    using static Constants.Constants.AdministratorConstants;
    public class BrandController : AdminController
    {
        private readonly IBrandService brandService;
        private readonly IMapper mapper;

        public BrandController(IMapper mapper, IBrandService brandService)
        {
            this.mapper = mapper;
            this.brandService = brandService;
        }
        public IActionResult Index([FromQuery] BrandListingViewModel query)
        {
            var model = mapper.Map<BrandListingViewModel>(brandService.All(query.CurrentPage, BrandListingViewModel.BrandsPerPage));

            return View(model);
        }

        public IActionResult Add()
        {
            return View(new BrandFormViewModel());
        }

        [HttpPost]
        public IActionResult Add(BrandFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!brandService.Add(model.Name, model.Description))
            {
                return BadRequest();
            }

            TempData[CreateGlobalKey] = "Brand created successfuly.";
            
            return RedirectToAction("Index", "Brand", new { area = AdministratorAreaName });
        }

        public IActionResult Edit(int id)
        {
            return View(mapper.Map<BrandFormViewModel>(brandService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(BrandFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!brandService.Edit(model.Id, model.Name, model.Description))
            {
                return BadRequest();
            }

            TempData[UpdateGlobalKey] = "Brand edited successfuly.";
            return RedirectToAction("Index", "Brand", new { area = AdministratorAreaName });
        }

        public IActionResult Delete(int id)
        {
            if (!brandService.Delete(id))
            {
                return BadRequest();
            }

            TempData[DeleteGlobalKey] = "Brand deleted successfuly.";
            return RedirectToAction("Index", "Brand", new { area = AdministratorAreaName });
        }
    }
}
