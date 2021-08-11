using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GlassesStore.Models.Common.Constants.AdministratorConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdministratorRoleName)]
    public class AdminController : Controller
    {
    }
}
