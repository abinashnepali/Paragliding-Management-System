﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paragliding_Management_System.Models;

namespace Paragliding_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string sessionVar = HttpContext.Session.GetString("UserDet"), name = string.Empty;
            if (sessionVar != null)
            {
                name = JsonConvert.DeserializeObject(sessionVar).ToString();
            }            
            ViewBag.Name = name;
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
