using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Paragliding_Management_System.Models;

namespace Paragliding_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private JObject UserEmail { get; set; }
        public IActionResult Index()
        {
            string sessionVar = HttpContext.Session.GetString("UserDet"), name = string.Empty, role = string.Empty, userID = string.Empty;
            if (sessionVar != null)
            {
                name = JsonConvert.DeserializeObject(sessionVar).ToString();
                UserEmail = JObject.Parse(name);
                name = (string)UserEmail["Email"];
                role = (string)UserEmail["RoleType"];
                userID = (string)UserEmail["UserID"];
                TempData["Name"] = name;
                TempData["UserID"] = userID;                
                TempData["RoleID"] = role;
                TempData.Keep();
            }
            else
            {
                TempData["Name"] = null;
                TempData["UserID"] = null;
                TempData["RoleID"] = null;
            }
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
