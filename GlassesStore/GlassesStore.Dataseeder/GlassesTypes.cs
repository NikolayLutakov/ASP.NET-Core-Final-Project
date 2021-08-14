namespace GlassesStore.Dataseeder
{
    using GlassesStore.Data;
    using GlassesStore.Models;
    using System.Linq;
    public class GlassesTypes
    {
        private readonly GlassesDbContext data;

        public GlassesTypes(GlassesDbContext data)
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
