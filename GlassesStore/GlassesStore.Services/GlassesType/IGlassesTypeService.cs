namespace GlassesStore.Services.GlassesType
{
    using System.Collections.Generic;
    using GlassesStore.Services.GlassesType.Models;
    public interface IGlassesTypeService
    {
        IEnumerable<GlassesTypeServiceModel> All();
    }
}
