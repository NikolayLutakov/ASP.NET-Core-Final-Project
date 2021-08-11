using AutoMapper;
using AutoMapper.QueryableExtensions;
using GlassesStore.Data;
using GlassesStore.Services.Brand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Brand
{
    public class BrandService : IBrandService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;
        public BrandService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public IEnumerable<BrandServiceModel> All()
            => data.Brands.OrderBy(b => b.Name)
                .ProjectTo<BrandServiceModel>(mapper.ConfigurationProvider)
                .ToList();
    }
}
