namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static GlassesStore.Constants.Constants.AdministratorConstants;

    [Area(AreaName)]
    [Authorize(Roles = AdministratorRoleName)]
    public class AdminController : Controller
    {
    }
}
