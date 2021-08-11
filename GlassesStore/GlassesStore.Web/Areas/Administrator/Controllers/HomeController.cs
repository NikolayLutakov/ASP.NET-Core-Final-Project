using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Areas.Administrator.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
