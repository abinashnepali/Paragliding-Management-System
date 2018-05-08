using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userID = User.Claims.Single(x => x.Type == "Id");
                var userName = User.Claims.Single(x => x.Type == "UserName");
                ViewBag.UName = userName.Value;
                ViewBag.UID = userID.Value;
            }
            else
            {
                ViewBag.UName = string.Empty;
                ViewBag.UID = string.Empty;
            }
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
    }
}