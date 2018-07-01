using System;
using System.Collections.Generic;
using System.Text;
using Demo.API.Datasource;
using Demo.API.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Demo.API.Model;
using System.Threading.Tasks;

namespace Demo.API.Test.UnitTest
{
    [TestClass]
    public class BookingServiceTest
    {
        [TestMethod]
        public void BookingServiceUnitTest_Booking_IsAvailable_return_true_on_seat_available()
        {
            //given
            var searchData = new Booking
            {
                StartDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                EndDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                NoOfPax = "1"
            };
            var moqRepo = new Mock<IRepository>();
            moqRepo.Setup(m => m.IsAvailable(It.IsAny<Booking>())).Returns(Task.FromResult(true));
            var sut = new BookingService(moqRepo.Object);

            //when
            var result = sut.IsAvailable(searchData);

            //then
            Assert.IsInstanceOfType(result, typeof(Task<bool>));

            Assert.IsTrue(result.Result);
        }
        [TestMethod]
        public void BookingServiceUnitTest_Booking_IsAvailable_return_false_on_seat_unavailable()
        {
            //given
            var searchData = new Booking
            {
                StartDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                EndDate = DateTime.Now.AddDays(4).ToString("dd-MM-yyyy"),
                NoOfPax = "1"
            };
            var moqRepo = new Mock<IRepository>();
            moqRepo.Setup(m => m.IsAvailable(It.IsAny<Booking>())).Returns(Task.FromResult(false));
            var sut = new BookingService(moqRepo.Object);

            //when
            var result = sut.IsAvailable(searchData);

            //then
            Assert.IsInstanceOfType(result, typeof(Task<bool>));
            Assert.IsFalse(result.Result);
        }
    }
}
