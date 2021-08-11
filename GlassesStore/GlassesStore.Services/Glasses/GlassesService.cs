using AutoMapper;
using AutoMapper.QueryableExtensions;
using GlassesStore.Data;
using GlassesStore.Services.Brand;
using GlassesStore.Services.Glasses.Models;
using GlassesStore.Services.GlassesType;
using System;
using System.Collections.Generic;

namespace GlassesStore.Services.Glasses
{
    using GlassesStore.Models;
    using Microsoft.Data.SqlClient;
    using System.Linq;

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

        public bool Add(
            string modelName,
            string description,
            decimal price,
            string imageUrl,
            int brandId,
            int typeId)
        {
            var brand = data.Brands.Find(brandId);
            var type = data.GlassesTypes.Find(typeId);

            if (brand == null || type == null)
            {
                return false;
            }

            var glasses = new Glasses
            {
                Model = modelName,
                Description = description,
                Price = price,
                ImageUrl = imageUrl,
                Brand = brand,
                Type = type
            };

            try
            {
                data.Glasses.Add(glasses);
                data.SaveChanges();
            }
            catch (SqlException)
            {
                return false;
            }

            return true;
        }

        public bool Edit(
           int id,
           string modelName,
           string description,
           decimal price,
           string imageUrl,
           int brandId,
           int typeId)
        {
            var brand = data.Brands.Find(brandId);
            var type = data.GlassesTypes.Find(typeId);
            var glasses = data.Glasses.Find(id);

            if (brand == null || type == null || glasses == null)
            {
                return false;
            }

            glasses.Model = modelName;
            glasses.Description = description;
            glasses.Price = price;
            glasses.ImageUrl = imageUrl;
            glasses.Brand = brand;
            glasses.Type = type;

            try
            {
                data.Update(glasses);
                data.SaveChanges();
            }
            catch (SqlException)
            {
                return false;
            }

            return true;
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
             => data.Glasses.Where(x => x.Id == id).Select(x => new GlassesFormServiceModel
             {
                 Id = x.Id,
                 ModelName = x.Model,
                 Description = x.Description,
                 Price = x.Price,
                 ImageUrl = x.ImageUrl,
                 BrandId = x.BrandId,
                 TypeId = x.TypeId,
                 BrandList = brandService.All().ToList(),
                 TypeList = glassesTypeService.All().ToList()
             })
             .FirstOrDefault();
    }
}
