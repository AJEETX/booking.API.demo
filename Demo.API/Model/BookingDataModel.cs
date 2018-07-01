using System;

namespace Demo.API.Model
{
    public class Booking
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string NoOfPax { get; set; }
    }
    public class SampleData
    {
        public Guid ID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int NoOfPax { get; set; }
    }
}
