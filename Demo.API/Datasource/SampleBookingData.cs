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
        Task<bool> IsAvaiable(Booking booking);
    }
    public class SampleBookingData: ISampleBookingData
    {
        IConfiguration _configuration;
        public static LiteCollection<SampleData> SampleData = null;
        public SampleBookingData(IConfiguration configuration)
        {
            _configuration = configuration;
            SampleData = new LiteDatabase(_configuration.GetSection("DBPath").Value).GetCollection<SampleData>("SampleData");
        }
        public async Task<bool> IsAvaiable(Booking booking)
        {
            return await Task.FromResult(Get(booking));
        }
        
        static bool Get(Booking booking)
        {
            if(SampleData.Count()==0) SampleData.InsertBulk(CreateBookingData());

            var result = SampleData.Find(b => b.StartDate == booking.StartDate && b.EndDate == booking.EndDate &&
                  b.NoOfPax >= int.Parse(booking.NoOfPax));

            if (result.Count() == 0) return false;

            return true;
        }
        static IEnumerable<SampleData> CreateBookingData()
        {
            Random random = new Random();
            for (var i = 0; i < 5; i++)
            {
                yield return new SampleData
                {
                    ID = Guid.NewGuid(),
                    StartDate = DateTimeOffset.Now.AddDays(i).ToString("dd-MM-yyyy"),
                    EndDate = DateTimeOffset.Now.AddDays(i).ToString("dd-MM-yyyy"),
                    NoOfPax = random.Next(0, 5)
                };
            }
        }
    }
}
