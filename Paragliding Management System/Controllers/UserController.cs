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
    public class UserController : Controller
    {
        UserDbl dalObj = new UserDbl();
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("firstName")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View(dalObj.GetAllUsers());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            }
            Users user = dalObj.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Users user)
        {
            if (id != user.UserID)
            {
                id = Convert.ToInt32(HttpContext.Session.GetString("id"));
            }
            if (ModelState.IsValid)
            {
                dalObj.AddUpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Users user = dalObj.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Users user = dalObj.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            dalObj.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}