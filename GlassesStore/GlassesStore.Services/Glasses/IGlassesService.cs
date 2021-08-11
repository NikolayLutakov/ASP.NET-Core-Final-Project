using GlassesStore.Services.Glasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Glasses
{
    public interface IGlassesService
    {
        GlassesFormServiceModel PopulateBookFormModel();

        GlassesFormServiceModel PopulateBookFormModel(int id);

        bool Add(
            string modelName,
            string description,
            decimal price,
            string imageUrl,
            int brandId,
            int typeId);

        IEnumerable<GlassesServiceModel> All();
    }
}
