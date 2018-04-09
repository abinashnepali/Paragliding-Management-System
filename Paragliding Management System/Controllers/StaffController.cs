using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class StaffController : Controller
    {
        StaffDbl objDal = new StaffDbl();
        public IActionResult Index()
        {
            return View(objDal.GetAllStaff());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind]Staff staff)
        {
            if (ModelState.IsValid)
            {
                objDal.AddUpdateStaff(staff);
                return RedirectToAction("Index", "Staff");
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
            Staff staff = objDal.GetStaffByID(id);

            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objDal.AddUpdateStaff(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Staff staff = objDal.GetStaffByID(id);

            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Staff staff = objDal.GetStaffByID(id);

            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objDal.DeleteStaff(id);
            return RedirectToAction("Index");
        }
    }
}