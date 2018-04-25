using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        StaffDbl objDal = new StaffDbl();

        public StaffController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            string firstName = HttpContext.Session.GetString("firstName");
            if (String.IsNullOrEmpty(firstName))
            {
                return RedirectToAction("Index", "Login");
            }
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
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');// FileName returns "fileName.ext"(with double quotes) in beta 3
            var filePath = hostingEnvironment.WebRootPath + "\\images\\staff\\" + fileName;
            using (var fileStream = new FileStream(Path.Combine(filePath), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Json(fileName);// PRG
        }
    }
}