namespace GlassesStore.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Card.Models;
    using GlassesStore.Web.Models.Shop;

    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            this.CreateMap<Purchase, PurchaseServiceModel>()
                .ForMember(x => x.Date, cfg => cfg.MapFrom(x => x.Date.ToString("d")))
                .ForMember(x => x.Card, cfg => cfg.MapFrom(x => x.Card.Number))
                .ForMember(x => x.Glasses, cfg => cfg.MapFrom(x => x.Glasses.Brand.Name + " " + x.Glasses.Model))
                .ForMember(x => x.Price, cfg => cfg.MapFrom(x => x.Cost));

            this.CreateMap<PurchaseListingServiceModel, PurchaseListingViewModel>();
        }
    }
}
