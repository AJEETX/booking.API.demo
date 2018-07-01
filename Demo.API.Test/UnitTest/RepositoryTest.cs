using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Demo.API.Datasource;
using Demo.API.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Demo.API.Test.UnitTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void RepositoryUnitTest_Booking_IsAvailable_return_true_on_seat_available()
        {
            //given
            var searchData = new Booking
            {
                StartDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                EndDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                NoOfPax = "1"
            };
            var bookingResponse = new BookingResponse { IsAvailable = true };
            var moqSampleBookingData = new Mock<ISampleBookingData>();
            moqSampleBookingData.Setup(m => m.IsAvailable(It.IsAny<Booking>())).Returns(Task.FromResult(bookingResponse));
            var sut = new Repository(moqSampleBookingData.Object);

            //when
            var result = sut.IsAvailable(searchData);

            //then
            Assert.IsInstanceOfType(result, typeof(Task<BookingResponse>));

            Assert.IsTrue(result.Result.IsAvailable);
        }
        [TestMethod]
        public void RepositoryUnitTest_Booking_IsAvailable_return_false_on_seat_unavailable()
        {
            //given
            var searchData = new Booking
            {
                StartDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                EndDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                NoOfPax = "1"
            };
            var bookingResponse = new BookingResponse { IsAvailable = false };
            var moqSampleBookingData = new Mock<ISampleBookingData>();
            moqSampleBookingData.Setup(m => m.IsAvailable(It.IsAny<Booking>())).Returns(Task.FromResult(bookingResponse));
            var sut = new Repository(moqSampleBookingData.Object);

            //when
            var result = sut.IsAvailable(searchData);

            //then
            Assert.IsInstanceOfType(result, typeof(Task<BookingResponse>));

            Assert.IsFalse(result.Result.IsAvailable);
        }

    }
}
