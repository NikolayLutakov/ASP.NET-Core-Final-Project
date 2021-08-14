namespace GlassesStore.Web.Infrastructure.Mapping
{
    using System.Linq;
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Brand.Models;
    using GlassesStore.Web.Areas.Administrator.Models.Brand;

    public class BrandProfile : Profile
    {
        public BrandProfile()
        {

            this.CreateMap<Brand, BrandServiceModel>()
                .ForMember(g => g.HasGlasses,
                                cfg => cfg.MapFrom(g => g.Glasses
                                                          .Count() == 0 ? false : true));

            this.CreateMap<BrandServiceModel, BrandViewModel>();

            this.CreateMap<BrandListingServiceModel, BrandListingViewModel>();

            this.CreateMap<BrandServiceModel, BrandFormViewModel>();
        }
    }
}
