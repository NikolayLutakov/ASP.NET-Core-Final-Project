using AutoMapper;
using GlassesStore.Services.Users.Models;
using GlassesStore.Web.Areas.Administrator.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Infrastructure.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<UserServiceModel, UserViewModel>()
                .ForMember(b => b.Role, cfg => cfg.MapFrom(b => b.Roles.FirstOrDefault()));
        }
    }
}
