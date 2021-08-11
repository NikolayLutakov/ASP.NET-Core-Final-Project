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
    using GlassesStore.Models;
    using Microsoft.Data.SqlClient;

    public class BrandService : IBrandService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;
        public BrandService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public bool Add(string name, string description)
        {
            var brand = new Brand
            {
                Name = name,
                Description = description
            };

            try
            {
                data.Add(brand);
                data.SaveChanges();
            }
            catch (SqlException)
            {
                return false;
            }

            return true;
            
        }

        public bool Edit(int id, string name, string description)
        {
            var brand = data.Brands.Find(id);

            if (brand == null)
            {
                return false;
            }

            brand.Name = name;
            brand.Description = description;

            try
            {
                data.Update(brand);
                data.SaveChanges();
            }
            catch (SqlException)
            {
                return false;
            }

            return true;

        }

        public IEnumerable<BrandServiceModel> All()
            => data.Brands.OrderBy(b => b.Name)
                .ProjectTo<BrandServiceModel>(mapper.ConfigurationProvider)
                .ToList();

        public BrandServiceModel GetById(int id)
            => data.Brands.Where(x => x.Id == id)
            .ProjectTo<BrandServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefault();
    }
}
