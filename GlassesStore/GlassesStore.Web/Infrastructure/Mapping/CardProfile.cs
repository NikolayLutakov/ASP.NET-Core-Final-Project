namespace GlassesStore.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Card.Models;
    using GlassesStore.Web.Models.Card;

    public class CardProfile : Profile
    {
        public CardProfile()
        {
            this.CreateMap<Card, CardServiceModel>()
               .ForMember(x => x.ExpiresOn, cfg => cfg.MapFrom(x => x.ExpiresOn.ToString("d")))
               .ForMember(x => x.Type, cfg => cfg.MapFrom(x => x.Type.TypeName))
               .ForMember(x => x.TypeId, cfg => cfg.MapFrom(x => x.Type.Id));

            this.CreateMap<CardType, CardTypeServiceModel>();

            this.CreateMap<CardListingServiceModel, CardListingViewModel>();
        }
    }
}
