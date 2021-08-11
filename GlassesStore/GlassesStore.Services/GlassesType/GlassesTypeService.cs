using AutoMapper;
using AutoMapper.QueryableExtensions;
using GlassesStore.Data;
using GlassesStore.Services.GlassesType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.GlassesType
{
    public class GlassesTypeService : IGlassesTypeService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;

        public GlassesTypeService(IMapper mapper, GlassesDbContext data)
        {
            this.mapper = mapper;
            this.data = data;
        }

        public IEnumerable<GlassesTypeServiceModel> All()
            => data.GlassesTypes
            .OrderBy(x => x.Name)
            .ProjectTo<GlassesTypeServiceModel>(mapper.ConfigurationProvider)
            .ToList();
    }
}
