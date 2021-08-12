namespace GlassesStore.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Routing;
    public static class EndpointRouteExtensions
    {
        public static void MapDefaultAreaRoute(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "Areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
