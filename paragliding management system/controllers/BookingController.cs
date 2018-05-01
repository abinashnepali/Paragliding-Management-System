using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers.Api
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}