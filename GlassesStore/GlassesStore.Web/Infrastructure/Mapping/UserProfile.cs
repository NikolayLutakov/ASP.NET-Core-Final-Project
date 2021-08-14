namespace GlassesStore.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using GlassesStore.Services.Users.Models;
    using GlassesStore.Web.Areas.Administrator.Models.User;
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            this.CreateMap<UserListingServiceModel, UserListingViewModel>();
        }
    }
}
