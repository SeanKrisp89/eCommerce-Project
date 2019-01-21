using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using N7Emporium.Models;

namespace N7Emporium.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is where I'll put the N7 Emporium description.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "This is where I'll put N7 Emporium contact details.";

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "This is where I'll detail my privacy policy.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
