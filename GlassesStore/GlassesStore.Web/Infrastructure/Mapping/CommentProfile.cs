namespace GlassesStore.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Comment.Models;
    using GlassesStore.Web.Models.Comment;
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            this.CreateMap<Comment, CommentServiceModel>()
               .ForMember(x => x.User, cfg => cfg.MapFrom(x => x.User.UserName.Substring(0, x.User.UserName.IndexOf("@"))))
               .ForMember(x => x.CreatedOn, cfg => cfg.MapFrom(x => x.CreatedOn.ToString("d")));

            this.CreateMap<CommentListingServiceModel, CommentListingViewModel>();
        }
    }
}
