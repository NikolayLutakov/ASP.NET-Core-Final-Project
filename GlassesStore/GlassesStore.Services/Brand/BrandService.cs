namespace GlassesStore.Services.Brand
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GlassesStore.Data;
    using GlassesStore.Services.Brand.Models;
    using GlassesStore.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

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
            catch (DbUpdateException)
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
            catch (DbUpdateException)
            {
                return false;
            }

            return true;

        }

        public BrandListingServiceModel All(int currentPage, int brandsPerPage)
        {
            var brandssQuery = data.Brands.OrderBy(b => b.Name);

            var totalBrands = brandssQuery.Count();

            var brands = brandssQuery.Skip((currentPage - 1) * brandsPerPage)
                .Take(brandsPerPage).ProjectTo<BrandServiceModel>(this.mapper.ConfigurationProvider);

            return new BrandListingServiceModel
            {
                TotalBrands = totalBrands,
                Brands = brands,
                CurrentPage = currentPage
            };
        }


        public BrandServiceModel GetById(int id)
            => data.Brands.Where(x => x.Id == id)
            .ProjectTo<BrandServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefault();

        public bool Delete(int id)
        {
            var brand = data.Brands
                .Include(x => x.Glasses)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (brand == null || brand.Glasses.Count() > 0)
            {
                return false;
            }

            try
            {
                data.Brands.Remove(brand);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
        public IEnumerable<BrandServiceModel> All()
           => data.Brands.OrderBy(b => b.Name)
               .ProjectTo<BrandServiceModel>(mapper.ConfigurationProvider)
               .ToList();
    }
}
