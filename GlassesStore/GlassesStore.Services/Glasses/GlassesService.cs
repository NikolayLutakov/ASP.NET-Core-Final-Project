using AutoMapper;
using AutoMapper.QueryableExtensions;
using GlassesStore.Data;
using GlassesStore.Services.Brand;
using GlassesStore.Services.Glasses.Models;
using GlassesStore.Services.GlassesType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Glasses
{
    public class GlassesService : IGlassesService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;
        private readonly IBrandService brandService;
        private readonly IGlassesTypeService glassesTypeService;
        public GlassesService(
            GlassesDbContext data,
            IMapper mapper,
            IBrandService brandService, 
            IGlassesTypeService glassesTypeService)
        {
            this.data = data;
            this.mapper = mapper;
            this.brandService = brandService;
            this.glassesTypeService = glassesTypeService;
        }

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GlassesServiceModel> All()
            => data.Glasses.ProjectTo<GlassesServiceModel>(this.mapper.ConfigurationProvider);

        public GlassesFormServiceModel PopulateBookFormModel()
            => new GlassesFormServiceModel
            {
                BrandList = brandService.All(),
                TypeList = glassesTypeService.All()
            };

        public GlassesFormServiceModel PopulateBookFormModel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
