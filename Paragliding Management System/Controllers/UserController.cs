using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paragliding_Management_System.AccountViewModels;
using Paragliding_Management_System.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Paragliding_Management_System.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserDbl dalObj;
        private readonly UsersDbContext _dbcontext;
        public UserController(UsersDbContext _dbcontext, UserDbl dalObj)
        {
            this._dbcontext = _dbcontext;
            this.dalObj = dalObj;
        }

        public IActionResult Index()
        {
            return View(dalObj.GetAllUsers());
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            UserViewModel model = new UserViewModel();
            AppUser user = _dbcontext.AppUser.Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            model.Id = user.Id;
            model.UserName = user.UserName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Phone = user.PhoneNumber;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody]UserViewModel model)
        {
            AppUser user = new AppUser();
            if (ModelState.IsValid)
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.Phone;
                AppUser exist = _dbcontext.Set<AppUser>().Find(model.Id);
                _dbcontext.Entry(exist).CurrentValues.SetValues(user);
                return RedirectToAction("Index");
            }
            return View(model);
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