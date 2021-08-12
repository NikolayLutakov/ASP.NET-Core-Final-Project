namespace GlassesStore.Web.Infrastructure.Mapping
{
    using System.Linq;
    using Microsoft.AspNetCore.Identity;
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Brand.Models;
    using GlassesStore.Services.Glasses.Models;
    using GlassesStore.Services.GlassesType.Models;
    using GlassesStore.Services.Users.Models;
    using GlassesStore.Web.Areas.Administrator.Models.Brand;
    using GlassesStore.Web.Areas.Administrator.Models.Glasses;
    using GlassesStore.Web.Areas.Administrator.Models.User;
    using GlassesStore.Web.Models.Shop;
    using GlassesStore.Services.Card.Models;
    using GlassesStore.Services.Comment.Models;

    public class MappingProfile : Profile
    {

        private readonly UserManager<User> userManager;

        public MappingProfile(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public MappingProfile()
        {

            this.CreateMap<UserServiceModel, UserViewModel>()
                .ForMember(b => b.Role, cfg => cfg.MapFrom(b => b.Roles.FirstOrDefault()));

            this.CreateMap<Glasses, GlassesServiceModel>()
                .ForMember(g => g.ModelName, cfg => cfg.MapFrom(g => g.Model))
                .ForMember(g => g.Brand, cfg => cfg.MapFrom(g => g.Brand.Name))
                .ForMember(g => g.Rating, cfg => cfg.MapFrom(g => (decimal)((g.GlassesRatings.Select(x => x.Rating).Sum() + 1) / (g.GlassesRatings.Count() + 1))))
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

            this.CreateMap<Card, CardServiceModel>();

            this.CreateMap<Brand, BrandServiceModel>()
                .ForMember(g => g.HasGlasses, 
                                cfg => cfg.MapFrom(g => g.Glasses
                                                          .Count() == 0 ? false : true));

            this.CreateMap<BrandServiceModel, BrandViewModel>();

            this.CreateMap<BrandServiceModel, BrandFormViewModel>();

            this.CreateMap<GlassesType, GlassesTypeServiceModel>();

            this.CreateMap<GlassesListingServiceModel, GlassesListingViewModel>();

            this.CreateMap<Purchase, PurchaseServiceModel>()
                .ForMember(x => x.Date, cfg => cfg.MapFrom(x => x.Date.ToString("d")))
                .ForMember(x => x.Card, cfg => cfg.MapFrom(x => x.Card.Number))
                .ForMember(x => x.Glasses, cfg => cfg.MapFrom(x => x.Glasses.Brand.Name + " " + x.Glasses.Model))
                .ForMember(x => x.Price, cfg => cfg.MapFrom(x => x.Glasses.Price));
        }
    }
}
