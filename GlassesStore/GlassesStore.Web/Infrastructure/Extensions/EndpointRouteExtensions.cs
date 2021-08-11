using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GlassesStore.Web.Infrastructure.Extensions
{
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
