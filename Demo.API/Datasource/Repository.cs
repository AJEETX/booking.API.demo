using Demo.API.Model;
using System;
using System.Threading.Tasks;

namespace Demo.API.Datasource
{
    public interface IRepository
    {
        Task<BookingResponse> IsAvailable(Booking booking);
    }
    public class Repository : IRepository
    {
        readonly ISampleBookingData _sampleBookingData;
        public Repository(ISampleBookingData sampleBookingData)
        {
            _sampleBookingData = sampleBookingData;
        }
        public async Task<BookingResponse> IsAvailable(Booking booking)
        {
            BookingResponse bookingResponse = null;

            if (booking == null) return bookingResponse; // always validate the data first before taking it down

            try
            {
                bookingResponse= await _sampleBookingData.IsAvailable(booking);
            }
            catch (Exception)
            {
                //yell / shout //catch // log
            }

            return bookingResponse;
        }
    }
}
