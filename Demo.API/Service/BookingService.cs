using Demo.API.Datasource;
using Demo.API.Model;
using System;
using System.Threading.Tasks;

namespace Demo.API.Service
{
    public interface IBookingService
    {
        Task<BookingResponse> IsAvailable(Booking booking);
    }
    public class BookingService : IBookingService
    {
        readonly IRepository _repository;
        public BookingService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookingResponse> IsAvailable(Booking booking)
        {
            BookingResponse bookingResponse = null;

            if (booking == null) return bookingResponse; // always validate the data first before taking it down

            return await FindBooking(booking);
        }
        async Task<BookingResponse> FindBooking(Booking booking)
        {
            BookingResponse bookingResponse = null;

            try
            {
                if (int.TryParse(booking.NoOfPax, out int Pax))
                    if (Pax == 0) return bookingResponse;

                if (DateTime.TryParse(booking.StartDate, out DateTime startDate) && DateTime.TryParse(booking.EndDate, out DateTime endDate))
                {
                    if (startDate > endDate) return bookingResponse; //end date to be on after the start date

                    var bookingData = new Booking{
                        StartDate = startDate.ToString("dd-MM-yyyy"),
                        EndDate = endDate.ToString("dd-MM-yyyy"),
                        NoOfPax = booking.NoOfPax
                    };

                    bookingResponse = await _repository.IsAvailable(bookingData);
                }
            }
            catch (Exception)
            {
                //yell / shout //catch // log
            }

            return bookingResponse;
        }
    }
}
