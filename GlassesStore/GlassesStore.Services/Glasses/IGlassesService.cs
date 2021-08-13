namespace GlassesStore.Services.Glasses
{
    using System.Collections.Generic;
    using GlassesStore.Services.Glasses.Models;
    public interface IGlassesService
    {
        GlassesServiceModel GetById(int id);

        GlassesListingServiceModel AllBooksForLikes(int currentPage, int glassesPerPage, IEnumerable<int> productIds);
        GlassesListingServiceModel All(int currentPage, int glassesPerPage);

        GlassesListingServiceModel Search(string searchTerm, int currentPage, int glassesPerPage);

        GlassesFormServiceModel PopulateGlassesFormModel();

        GlassesFormServiceModel PopulateGlassesFormModel(int id);

        bool Add(
            string modelName,
            string description,
            decimal price,
            string imageUrl,
            int brandId,
            int typeId);

        public bool Edit(
            int id,
            string modelName,
            string description,
            decimal price,
            string imageUrl,
            int brandId,
            int typeId);

        public bool Delete(int id);
    }
}
