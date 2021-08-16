namespace GlassesStore.Web.Infrastructure.Mapping
{
    using AutoMapper;
    using GlassesStore.Models;
    using GlassesStore.Services.Contacts.Models;
    using GlassesStore.Web.Models.Home;

    public class ContactProffile : Profile
    {
        public ContactProffile()
        {
            this.CreateMap<ContactMessage, ContactMessageServiceModel>()
                .ForMember(x => x.CreatedOn, cfg => cfg.MapFrom(x => x.CreatedOn.ToString("d")));

            this.CreateMap<ContactMessageListingServiceModel, ContactMessagesListingViewModel>();
        }
    }
}
