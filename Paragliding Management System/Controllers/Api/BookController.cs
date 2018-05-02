using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Mvc;

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
            var booking = bookingDbl.GetAllBooking();
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
            var booking = bookingDbl.BookingCancel(staffId);
            return Ok(booking);
        }

    }
}