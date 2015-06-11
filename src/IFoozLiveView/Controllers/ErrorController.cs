using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace IFoozLiveView.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
