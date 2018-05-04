using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Paragliding_Management_System.Controllers
{
    public class LoginController : Controller
    {
        Logindbl dbObj = new Logindbl();
        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password, string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                if (dbObj.ValidateUser(email, password))
                {
                    Users user = dbObj.GetUserDetails(email);
                    HttpContext.Session.SetString("UserDet", JsonConvert.SerializeObject(user));
                    //string role = Enum.GetName(typeof(Role), user.RoleType);
                    //HttpContext.Session.SetString("id", user.UserID.ToString());
                    //HttpContext.Session.SetString("firstName", user.FirstName);
                    //HttpContext.Session.SetString("lastName", user.LastName);
                    //HttpContext.Session.SetString("email", user.Email);
                    //HttpContext.Session.SetString("role", role);                  
                    return Redirect(GetRedirectUrl(returnUrl));
                }
                ViewData["Message"] = "Username or password is invalid.";
                return View();
            }
            // user authN failed
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }
            return returnUrl;
        }
    }
}