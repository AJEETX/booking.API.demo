using Demo.API.Datasource;
using Demo.API.Model;
using System;
using System.Threading.Tasks;

namespace Demo.API.Service
{
    public interface IBookingService
    {
        Task<bool> IsAvailable(Booking booking);
    }
    public class BookingService : IBookingService
    {
        readonly IRepository _repository;
        public BookingService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> IsAvailable(Booking booking)
        {
            bool bookingAvailable = false;

            if (booking == null) return bookingAvailable;

            return await FindBooking(booking);
        }
        async Task<bool> FindBooking(Booking booking)
        {
            bool available = false;

            if (int.TryParse(booking.NoOfPax, out int Pax))
                if (Pax == 0) return available;

            if (DateTime.TryParse(booking.StartDate, out DateTime startDate) && DateTime.TryParse(booking.EndDate, out DateTime endDate))
            {
                var bookingData = new Booking {
                    StartDate =startDate.ToString("dd-MM-yyyy"),
                    EndDate =endDate.ToString("dd-MM-yyyy"),
                    NoOfPax=booking.NoOfPax
                };
                available =await _repository.IsAvailable(bookingData);
            }
            return available;
        }
    }
}
