using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class UserController : Controller
    {
        DAL objDal = new DAL();
        public IActionResult Index()
        {
            //return RedirectToAction("Register");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind]Users user)
        {
            if (ModelState.IsValid)
            {
                objDal.AddUpdateUser(user);
                return RedirectToAction("Index", "");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Users user = objDal.GetUserByID(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}