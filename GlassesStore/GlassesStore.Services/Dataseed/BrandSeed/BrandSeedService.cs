namespace GlassesStore.Services.Dataseed.BrandSeed
{

    using System.Linq;
    using System.Collections.Generic;
    using GlassesStore.Data;
    using GlassesStore.Models;

    public class BrandSeedService : IBrandSeedService
    {
        private readonly GlassesDbContext data;
        private const string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae convallis turpis. Nulla tincidunt metus id lectus tempor molestie.";

        public BrandSeedService(GlassesDbContext data)
        {
            this.data = data;
        }

        public void Seed()
        {

            if (data.Brands.Any())
            {
                return;
            }

            var brands = new List<Brand>();
            var brandNames = new List<string>
            {
                "Calvin Klein",
                "Diesel",
                "Guess",
                "Harley Davidson",
                "Level One",
                "Ray Ban"
            };

            foreach (var brand in brandNames)
            {
                var brandToAdd = new Brand
                {
                    Name = brand,
                    Description = description
                };

                brands.Add(brandToAdd);
            }

            data.Brands.AddRange(brands);
            data.SaveChanges();
        }
    }
}
