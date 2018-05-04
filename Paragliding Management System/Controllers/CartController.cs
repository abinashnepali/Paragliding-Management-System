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
            if (TempData["Name"] != null)
            {
                ViewBag.UName = TempData["Name"].ToString();
            }
            else
            {
                ViewBag.UName = null;
            }
            if (TempData["UserID"] != null)
            {
                ViewBag.UID = TempData["UserID"].ToString();
            }
            else
            {
                ViewBag.UID = null;
            }
            return View();
        }
    }
}