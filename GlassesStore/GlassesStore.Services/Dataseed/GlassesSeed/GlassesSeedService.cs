namespace GlassesStore.Services.Dataseed.GlassesSeed
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using GlassesStore.Data;
    using GlassesStore.Models;

    public class GlassesSeedService : IGlassesSeedService
    {
        private readonly GlassesDbContext data;
        private const string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vitae convallis turpis. Nulla tincidunt metus id lectus tempor molestie.";

        public GlassesSeedService(GlassesDbContext data)
        {
            this.data = data;
        }

        public void Seed()
        {
            if (data.Glasses.Any())
            {
                return;
            }

            var brandsIds = data.Brands.Select(x => x.Id).ToList();
            var typesIds = data.GlassesTypes.Select(x => x.Id).ToList();

            if (brandsIds == null || typesIds == null)
            {
                return;
            }

            var models = new List<string>()
            {
                "Model1", "Model2", "Model3", "Model4", "Model5"
            };

            var imageUrls = new List<string>()
            {
                "https://myopticonline.com/media/catalog/product/cache/1/image/574x574/9df78eab33525d08d6e5fb8d27136e95/h/d/hd0939x_02a_01.jpg",
                "https://myopticonline.com/media/catalog/product/cache/1/image/574x574/9df78eab33525d08d6e5fb8d27136e95/h/d/hd0936x_20a_01.jpg",
                "https://contents.mediadecathlon.com/p1981373/k$9b63009207eb708712157b83d42dd74b/mh-540-adult-category-3-hiking-sunglasses-blue.jpg?&f=800x800",
                "https://cdn.shopify.com/s/files/1/0084/1616/5946/products/FlamingosOnABoozeCruise_straighton_2_1000x.jpg?v=1601591873",
                "https://www.ochilar.bg/media/t43s-4/463.webp",
                "https://www.framesdirect.com/product_elarge_images/Carrera-sunglasses-1007-S-08079O.jpg"
            };

            var brandRandomMaxIndex = brandsIds.Count();
            var typeRandomMaxIndex = typesIds.Count();
            var modelRandomMaxIndex = models.Count();
            var imageRandomMaxIndex = imageUrls.Count();
            const int randomMinValue = 0;

            var random = new Random();

            var glassesList = new List<Glasses>();

            for (int i = 0; i < 30; i++)
            {
                var glasses = new Glasses
                {
                    BrandId = brandsIds[random.Next(randomMinValue, brandRandomMaxIndex)],
                    TypeId = typesIds[random.Next(randomMinValue, typeRandomMaxIndex)],
                    Description = description,
                    ImageUrl = imageUrls[random.Next(randomMinValue, imageRandomMaxIndex)],
                    Model = models[random.Next(randomMinValue, modelRandomMaxIndex)],
                    Price = (decimal)random.Next(randomMinValue, 500)
                };

                glassesList.Add(glasses);
            }

            data.AddRange(glassesList);
            data.SaveChanges();
        }
    }
}
