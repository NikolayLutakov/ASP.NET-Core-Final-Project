namespace GlassesStore.Web.Infrastructure.Mapping
{
    using System.Linq;
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Comment.Models;
    using GlassesStore.Services.Glasses.Models;
    using GlassesStore.Services.GlassesType.Models;
    using GlassesStore.Services.Like.Models;
    using GlassesStore.Web.Areas.Administrator.Models.Glasses;
    using GlassesStore.Web.Models.Shop;

    public class GlassesProfile : Profile
    {
        public GlassesProfile()
        {
            this.CreateMap<Glasses, GlassesServiceModel>()
               .ForMember(g => g.ModelName, cfg => cfg.MapFrom(g => g.Model))
               .ForMember(g => g.Type, cfg => cfg.MapFrom(g => g.Type.Name))
               .ForMember(g => g.Brand, cfg => cfg.MapFrom(g => g.Brand.Name))
               .ForMember(g => g.Likes, cfg => cfg.MapFrom(g => g.GlassesLikes.Select(l => new LikeServiceModel { GlassesId = l.GlassesId, UserId = l.UserId })))
               .ForMember(g => g.PurchasesCount, cfg => cfg.MapFrom(g => g.Purchases.Count()))
               .ForMember(g => g.Comments, cfg => cfg.MapFrom(g => g.Comments.OrderByDescending(c => c.CreatedOn).Select(x => new CommentServiceModel
               {
                   Id = x.Id,
                   Content = x.Content,
                   CreatedOn = x.CreatedOn.ToString("d"),
                   GlassesId = x.GlassesId,
                   UserId = x.UserId,
                   User = x.User.UserName.Substring(0, x.User.UserName.IndexOf("@"))
               })));

            this.CreateMap<GlassesServiceModel, GlassesViewModel>();

            this.CreateMap<GlassesFormServiceModel, GlassesFormViewModel>();

            this.CreateMap<GlassesServiceModel, GlassesDetailsViewModel>();

            this.CreateMap<GlassesListingServiceModel, GlassesListingViewModel>();

            this.CreateMap<GlassesListingServiceModel, AdminGlassesListingViewModel>();

            this.CreateMap<GlassesType, GlassesTypeServiceModel>();
        }
    }
}
