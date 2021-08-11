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

        IEnumerable<GlassesServiceModel> All();
    }
}
