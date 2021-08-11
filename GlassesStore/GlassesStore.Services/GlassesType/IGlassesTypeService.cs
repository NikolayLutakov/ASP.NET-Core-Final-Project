using GlassesStore.Services.GlassesType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.GlassesType
{
    public interface IGlassesTypeService
    {
        IEnumerable<GlassesTypeServiceModel> All();
    }
}
