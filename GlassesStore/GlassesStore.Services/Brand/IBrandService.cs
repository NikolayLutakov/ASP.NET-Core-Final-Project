namespace GlassesStore.Services.Brand
{
    using System.Collections.Generic;
    using GlassesStore.Services.Brand.Models;

    public interface IBrandService
    {
        IEnumerable<BrandServiceModel> All();

        BrandServiceModel GetById(int id);

        bool Add(string name, string description);

        bool Edit(int id, string name, string description);

        bool Delete(int id);
    }
}
