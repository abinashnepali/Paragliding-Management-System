using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Paragliding_Management_System.Controllers.Api
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {        
                client.BaseAddress = new Uri("http://localhost:58845/api/");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("Book/All").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                IEnumerable<Book> data = JsonConvert.DeserializeObject<IEnumerable<Book>>(stringData);
                return View(data);
            }
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView("_AddBooking");
        }

        public PartialViewResult EditBooking(int? id)
        {
            return PartialView("_EditBooking");
        }

        [HttpGet]
        public PartialViewResult CancelBooking(int id)
        {
            return PartialView("_CancelBooking");
        }

    }
}
