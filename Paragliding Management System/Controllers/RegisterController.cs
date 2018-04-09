using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class RegisterController : Controller
    {
        Registerdb objDal = new Registerdb();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind]Users user)
        {
            if (ModelState.IsValid)
            {
                objDal.AddUpdateUser(user);
                return RedirectToAction("Index", "");
            }
            return View();
        }
    }
}