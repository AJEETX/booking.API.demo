using Demo.API.Model;
using Demo.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/booking/{startdate}/{enddate}/{Pax}")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string startdate,string enddate,string pax)
        {
            if (startdate == null || enddate == null || pax == null) return BadRequest();

            bool bookingAvailable = false;

            var booking = new Booking { StartDate = startdate, EndDate = enddate, NoOfPax = pax };

            bookingAvailable=await _bookingService.IsAvailable(booking);

            return Ok(bookingAvailable);
        }
    }
}