using AutoMapper;
using GlassesStore.Models;
using GlassesStore.Services.Brand.Models;
using GlassesStore.Services.Glasses.Models;
using GlassesStore.Services.GlassesType.Models;
using GlassesStore.Services.Users.Models;
using GlassesStore.Web.Areas.Administrator.Models.Glasses;
using GlassesStore.Web.Areas.Administrator.Models.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Infrastructure.Mapping
{
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
                .ForMember(g => g.Rating, cfg => cfg.MapFrom(g => 1.0m));//(decimal)(g.GlassesRatings.Select(x => x.Rating).Sum() + 1 / g.GlassesRatings.Count() + 1)));

            this.CreateMap<GlassesServiceModel, GlassesViewModel>();

            this.CreateMap<GlassesFormServiceModel, GlassesFormViewModel>();

            this.CreateMap<Brand, BrandServiceModel>();

            this.CreateMap<GlassesType, GlassesTypeServiceModel>();
        }
    }
}
