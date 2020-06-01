using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace FlightManagement.Test
{
    public class FlightControllerTests
    {
        [Fact]
        public async Task Index_ReturnsFlights()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            IEnumerable<Flight> flights = new List<Flight>
            {

            };

            unitOfWorkMock.Setup(uof => uof.FlightRepository.GetAsync(It.IsAny<Expression<Func<Flight, bool>>>(), It.IsAny<Func<IQueryable<Flight>, IOrderedQueryable<Flight>>>(), It.IsAny<string>())).Returns(Task.FromResult(flights));
            var controller = new FlightsController(unitOfWorkMock.Object);

            //Act
            var result = await controller.Index();
            
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Flight>>(viewResult.Model);
            unitOfWorkMock.Verify(mock => mock.FlightRepository.GetAsync(It.IsAny<Expression<Func<Flight, bool>>>(), It.IsAny<Func<IQueryable<Flight>, IOrderedQueryable<Flight>>>(), It.IsAny<string>()), Times.Once);
        }
    }
}
