using Demo.API.Model;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Datasource
{
    public interface IRepository
    {
        Task<bool> IsAvailable(Booking booking);
    }
    public class Repository : IRepository
    {
        readonly ISampleBookingData _sampleBookingData;
        public Repository(ISampleBookingData sampleBookingData)
        {
            _sampleBookingData = sampleBookingData;
        }
        public async Task<bool> IsAvailable(Booking booking)
        {
            return await _sampleBookingData.IsAvaiable(booking);
        }
    }
}
