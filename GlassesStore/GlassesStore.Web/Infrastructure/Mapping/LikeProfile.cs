namespace GlassesStore.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Like.Models;

    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            this.CreateMap<GlassesLike, LikeServiceModel>();
        }
    }
}
