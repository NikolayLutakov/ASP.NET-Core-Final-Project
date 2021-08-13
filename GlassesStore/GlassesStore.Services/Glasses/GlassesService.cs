namespace GlassesStore.Services.Glasses
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GlassesStore.Data;
    using GlassesStore.Services.Brand;
    using GlassesStore.Services.Glasses.Models;
    using GlassesStore.Services.GlassesType;
    using GlassesStore.Models;

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
            catch (DbUpdateException)
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
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            var glassesToDelete = data.Glasses.Find(id);

            var commentsToDelete = data.Comments
                .Where(x => x.GlassesId == glassesToDelete.Id)
                .ToList();

            if (glassesToDelete == null || glassesToDelete.Purchases.Count() > 0)
            {
                return false;
            }
            try
            {
                data.RemoveRange(commentsToDelete);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            try
            {
                data.Remove(glassesToDelete);
                data.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                return false;
            }

            return true;
        }

        public GlassesListingServiceModel All(int currentPage, int glassesPerPage)
        {
            var glassesQuery = data.Glasses
                 .OrderBy(x => x.Brand.Name)
                 .ThenBy(x => x.Model);

            var totalGlasses = glassesQuery.Count();

            var glasses = glassesQuery.Skip((currentPage - 1) * glassesPerPage)
                .Take(glassesPerPage).ProjectTo<GlassesServiceModel>(this.mapper.ConfigurationProvider);

            return new GlassesListingServiceModel
            {
                TotalGlasses = totalGlasses,
                Glasses = glasses,
                CurrentPage = currentPage
            };
        }
            

        public GlassesFormServiceModel PopulateGlassesFormModel()
            => new GlassesFormServiceModel
            {
                BrandList = brandService.All(),
                TypeList = glassesTypeService.All()
            };

        public GlassesFormServiceModel PopulateGlassesFormModel(int id)
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

        public GlassesListingServiceModel Search(string searchTerm, int currentPage, int glassesPerPage)
        {
            IQueryable<Glasses> glassesQuery = data.Glasses.OrderBy(x => x.Brand.Name).ThenBy(x => x.Model);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                glassesQuery = glassesQuery
                    .Where(x => (x.Brand.Name.ToLower() + " " + x.Model.ToLower() + " " + x.Description.ToLower() + " " + x.Type.Name.ToLower())
                    .Contains(searchTerm.ToLower()));          
            }

            var totalGlasses = glassesQuery.Count();

            var glasses = glassesQuery.Skip((currentPage - 1) * glassesPerPage)
                .Take(glassesPerPage).ProjectTo<GlassesServiceModel>(this.mapper.ConfigurationProvider);

            return new GlassesListingServiceModel
            {
                TotalGlasses = totalGlasses,
                Glasses = glasses,
                CurrentPage = currentPage
            };
        }

        public GlassesServiceModel GetById(int id)
            => data.Glasses.Where(x => x.Id == id)
                .ProjectTo<GlassesServiceModel>(mapper.ConfigurationProvider)
                .FirstOrDefault();
    }
}
