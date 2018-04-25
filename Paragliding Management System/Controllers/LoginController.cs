using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class LoginController : Controller
    {
        Logindbl dbObj = new Logindbl();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            if (dbObj.ValidateUser(email, password))
            {
                Users user = dbObj.GetUserDetails(email);
                string role = Enum.GetName(typeof(Role), user.RoleType);
                HttpContext.Session.SetString("id", user.UserID.ToString());
                HttpContext.Session.SetString("firstName", user.FirstName);
                HttpContext.Session.SetString("lastName", user.LastName);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("role", role);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewData["Message"] = "Username or password is invalid.";
                return View();
            }
        }
    }
}