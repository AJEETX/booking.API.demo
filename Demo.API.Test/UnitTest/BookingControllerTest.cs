using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Demo.API.Model;
using Demo.API.Controllers;
using Demo.API.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Test.UnitTest
{
    [TestClass]
    public class BookingControllerTest
    {
        [TestMethod]
        public void BookingControllerUnitTest_IsAvailable_return_true_on_seat_available()
        {
            //given
            string date = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy");
            var moqBookingService = new Mock<IBookingService>();
            moqBookingService.Setup(m => m.IsAvailable(It.IsAny<Booking>())).Returns(Task.FromResult(true));
            var sut = new BookingController(moqBookingService.Object);

            //when
            var result = sut.Get(date, date, "1");
            var okResult = result.Result as OkObjectResult;
            
            //then
            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(true, okResult.Value);
        }

        [TestMethod]
        public void BookingControllerUnitTest_IsAvailable_return_false_on_seat_unavailable()
        {
            //given
            string date = DateTime.Now.AddDays(1).ToString("dd-MM-yyyy");
            var moqBookingService = new Mock<IBookingService>();
            moqBookingService.Setup(m => m.IsAvailable(It.IsAny<Booking>())).Returns(Task.FromResult(false));
            var sut = new BookingController(moqBookingService.Object);

            //when
            var result = sut.Get(date, date, "1");
            var okResult = result.Result as OkObjectResult;

            //then
            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(false, okResult.Value);
        }
    }
}
