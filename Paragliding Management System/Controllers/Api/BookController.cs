using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Paragliding_Management_System.Controllers.Api
{
    [Route("api/Book")]
    public class BookController : Controller
    {
        private readonly BookingDbl bookingDbl;
        public BookController(BookingDbl bookingDbl)
        {
            this.bookingDbl = bookingDbl;
        }
        [Route("All")]
        [HttpGet]
        public IActionResult GET()
        {
            //var booking = bookingDbl.GetAllBooking();
            //return Ok(booking);
            return Ok();
        }

        [Route("History")]
        [HttpGet]
        public IActionResult Histroy()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var booking = bookingDbl.GetAllBooking(userId);
            return Ok(booking);
        }

        [Route("{staffId:int}")]
        [HttpGet]
        public IActionResult GET(int? staffId)
        {
            var booking = bookingDbl.GetBookingByID(staffId);
            return Ok(booking);
        }

        [Route("Save")]
        [HttpPost]
        public IActionResult POST([FromBody]Book book)
        {
            var booking = bookingDbl.AddUpdateBooking(book);
            return Created("Booking Added Successfully", booking);
        }

        [Route("Update")]
        [HttpPost]
        public IActionResult PUT([FromBody]Book book)
        {
            var booking = bookingDbl.AddUpdateBooking(book);
            return Created("Booking Updated Successfully", booking);
        }

        [Route("Cancel/{staffId:int}")]
        [HttpPost]
        public IActionResult DELETE(int? staffId)
        {
            bookingDbl.BookingCancel(staffId);
            return Ok();
        }

    }
}