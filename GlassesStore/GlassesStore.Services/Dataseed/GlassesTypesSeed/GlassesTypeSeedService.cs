namespace GlassesStore.Services.Dataseed.GlassesTypesSeed
{
    using GlassesStore.Data;    
    using System.Linq;
    using GlassesStore.Models;

    public class GlassesTypeSeedService : IGlassesTypeSeedService
    {
        private readonly GlassesDbContext data;

        public GlassesTypeSeedService(GlassesDbContext data)
        {
            this.data = data;
        }

        public void Seed()
        {
            if (data.GlassesTypes.Any())
            {
                return;
            }

            data.GlassesTypes.AddRange(new[]
            {
                new GlassesType { Name = "Sunglasses"},
                new GlassesType { Name = "Prescription glasses" },
                new GlassesType { Name = "Lenses"}
            });

            data.SaveChanges();
        }
    }
}
