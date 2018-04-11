using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragliding_Management_System.Models;

namespace Paragliding_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            if (HttpContext.Current.Session != null)
            {
                ViewData["FirstName"] = HttpContext.Session.GetString("firstName");
                ViewData["LastName"] = HttpContext.Session.GetString("lastName");
                ViewData["Email"] = HttpContext.Session.GetString("email");
                ViewData["Role"] = HttpContext.Session.GetString("role");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
