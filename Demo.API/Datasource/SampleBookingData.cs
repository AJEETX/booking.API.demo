using Demo.API.Model;
using LiteDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Datasource
{
    public interface ISampleBookingData
    {
        Task<BookingResponse> IsAvailable(Booking booking);
    }
    public class SampleBookingData : ISampleBookingData
    {
        IConfiguration _configuration;
        static int noOfDays = 0;
        public static LiteCollection<SampleData> SampleData = null;
        public SampleBookingData(IConfiguration configuration)
        {
            _configuration = configuration;
            SampleData = new LiteDatabase(_configuration.GetSection("DBPath").Value).GetCollection<SampleData>("SampleData");
            noOfDays = int.Parse(_configuration.GetSection("noOfDays").Value);
        }
        public async Task<BookingResponse> IsAvailable(Booking booking)
        {
            BookingResponse bookingResponse = null;
            try
            {
                #region Code to create sample data

                SampleData.Delete(d => d.NoOfPax >= 0);

                if (SampleData.Count() == 0) SampleData.InsertBulk(CreateBookingData());

                var all = SampleData.FindAll();

                #endregion

                var result = SampleData.Find(b => b.StartDate == booking.StartDate && b.EndDate == booking.EndDate &&
                      b.NoOfPax >= int.Parse(booking.NoOfPax));

                bookingResponse = new BookingResponse { IsAvailable = result.Count() == 0?false:true };
            }
            catch (Exception)
            {
                //yell / shout //catch // log
            }
            return await Task.FromResult(bookingResponse);
        }

        static IEnumerable<SampleData> CreateBookingData()
        {
            Random random = new Random();
            for (var i = 1; i < noOfDays; i++) {

                for (var j = i; j < noOfDays; j++) {

                    yield return new SampleData {

                        ID = Guid.NewGuid(), StartDate = DateTimeOffset.Now.AddDays(i).ToString("dd-MM-yyyy"),

                        EndDate = DateTimeOffset.Now.AddDays(j).ToString("dd-MM-yyyy"), NoOfPax = random.Next(0, 9)
                    };
                }
            }
        }
    }
}