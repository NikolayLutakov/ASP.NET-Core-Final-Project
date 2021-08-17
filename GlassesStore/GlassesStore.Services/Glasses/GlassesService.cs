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
    using static GlassesStore.Constants.Constants.Sorting;

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

            var likesToDelete = data.GlassesLikes
                .Where(x => x.GlassesId == glassesToDelete.Id)
                .ToList();

            if (glassesToDelete == null || glassesToDelete.Purchases.Count() > 0)
            {
                return false;
            }

            try
            {
                data.RemoveRange(likesToDelete);
                data.SaveChanges();
            }
            catch (DbUpdateException)
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
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
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

        public GlassesListingServiceModel Search(string searchTerm, int currentPage, int glassesPerPage, int filterTypeId, string orderBy)
        {
            IQueryable<Glasses> glassesQuery = data.Glasses;

            if (filterTypeId != 0)
            {
                glassesQuery = glassesQuery.Where(x => x.Type.Id == filterTypeId);
            }

            glassesQuery = orderBy switch
            {
                PriceAsc => glassesQuery.OrderBy(g => g.Price),
                PriceDesc => glassesQuery.OrderByDescending(g => g.Price),
                Buy => glassesQuery.OrderByDescending(g => g.Purchases.Count()),
                Like => glassesQuery.OrderByDescending(g => g.GlassesLikes.Count()),
                _ => glassesQuery.OrderBy(x => x.Brand.Name).ThenBy(x => x.Model)
            };


            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                glassesQuery = glassesQuery
                    .Where(x => (x.Brand.Name.ToLower() + " " + x.Description.ToLower() + " " + x.Type.Name.ToLower())
                    .Contains(searchTerm.ToLower()));          
            }

            var totalGlasses = glassesQuery.Count();
            var types = glassesTypeService.All();
            var glasses = glassesQuery
                .Skip((currentPage - 1) * glassesPerPage)
                .Take(glassesPerPage)
                .ProjectTo<GlassesServiceModel>(this.mapper.ConfigurationProvider)
                .AsSingleQuery();

            return new GlassesListingServiceModel
            {
                TotalGlasses = totalGlasses,
                Glasses = glasses,
                CurrentPage = currentPage,
                GlassesTypes = types
            };
        }

        public GlassesServiceModel GetById(int id)
            => data.Glasses.Where(x => x.Id == id)
                .ProjectTo<GlassesServiceModel>(mapper.ConfigurationProvider)
                .AsSingleQuery()
                .FirstOrDefault();

        public GlassesListingServiceModel AllGlassesForLikes(int currentPage, int glassesPerPage, IEnumerable<int> productIds)
        {
            var glassesQuery = data.Glasses
                 .Where(x => productIds.Contains(x.Id))
                 .OrderBy(x => x.Brand.Name)
                 .ThenBy(x => x.Model);

            var totalGlasses = glassesQuery.Count();

            var glasses = glassesQuery.Skip((currentPage - 1) * glassesPerPage)
                .Take(glassesPerPage)
                .ProjectTo<GlassesServiceModel>(this.mapper.ConfigurationProvider)
                .AsSingleQuery();

            return new GlassesListingServiceModel
            {
                TotalGlasses = totalGlasses,
                Glasses = glasses,
                CurrentPage = currentPage
            };
        }
    }
}
