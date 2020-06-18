using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Web.Controllers;
using FlightManagement.Web.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace FlightManagement.Controllers.Test
{
    public class FlightControllerTest
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IDistanceCalculator> _distanceCalculatorMock;
        private Mock<IKeroseneCalculator> _keroseneCalculatorMock;
        private FlightsController _flightsController;

        public FlightControllerTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _distanceCalculatorMock = new Mock<IDistanceCalculator>();
            _keroseneCalculatorMock = new Mock<IKeroseneCalculator>();

            _flightsController = new FlightsController(_unitOfWorkMock.Object, 
                _distanceCalculatorMock.Object, 
                _keroseneCalculatorMock.Object);
        }

        [Fact]
        public async Task Index_ReturnsFlights()
        {
            //Arrange

            IEnumerable<Flight> flights = new List<Flight>();
            _unitOfWorkMock.Setup(uof => uof.FlightRepository.GetAsync(It.IsAny<Expression<Func<Flight, bool>>>(), It.IsAny<Func<IQueryable<Flight>, IOrderedQueryable<Flight>>>(), It.IsAny<string>())).Returns(Task.FromResult(flights));

            //Act
            var result = await _flightsController.Index();
            
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Flight>>(viewResult.Model);
            _unitOfWorkMock.Verify(uof => uof.FlightRepository.GetAsync(It.IsAny<Expression<Func<Flight, bool>>>(), It.IsAny<Func<IQueryable<Flight>, IOrderedQueryable<Flight>>>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task CreateGet_ViewBagShouldContainAirportsAndAirplanes()
        {
            // Arrange
            IEnumerable<Airport> airports = new List<Airport>();
            IEnumerable<Airplane> airplanes = new List<Airplane>();

            _unitOfWorkMock.Setup(uof => uof.AirplaneRepository.GetAllAsync()).Returns(Task.FromResult(airplanes));
            _unitOfWorkMock.Setup(uof => uof.AirportRepository.GetAllAsync()).Returns(Task.FromResult(airports));

            //Act
            var result = await _flightsController.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Airport>>(_flightsController.ViewBag.Airports);
            Assert.IsType<List<Airplane>>(_flightsController.ViewBag.Airplanes);

            _unitOfWorkMock.Verify(uof => uof.AirplaneRepository.GetAllAsync());
            _unitOfWorkMock.Verify(uof => uof.AirportRepository.GetAllAsync());
        }

        [Fact]
        public async Task CreatePost_ShouldCreateNewFlight()
        {
            // Arrange
            var newFlight = new FlightViewModel();
            _unitOfWorkMock.Setup(uof => uof.AirplaneRepository.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(new Airplane()));
            _unitOfWorkMock.Setup(uof => uof.AirportRepository.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(new Airport()));
            _unitOfWorkMock.Setup(uof => uof.FlightRepository.Add(It.IsAny<Flight>()));

            // Act
            var result = await _flightsController.Create(newFlight);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            _unitOfWorkMock.Verify(uof => uof.AirplaneRepository.GetByIdAsync(It.IsAny<int>()));
            _unitOfWorkMock.Verify(uof => uof.AirportRepository.GetByIdAsync(It.IsAny<int>()));
            _unitOfWorkMock.Verify(uof => uof.FlightRepository.Add(It.IsAny<Flight>()));
            _unitOfWorkMock.Verify(uof => uof.SaveAsync());
        }

        [Fact]
        public async Task Detail_ShouldDoDistanceAndKereseneCalculation()
        {
            // Arrange
            var airplane = new Airplane { Id = 1, Name = "Airplane1", KeroseneConsumption = 10 };
            var airport = new Airport { Id = 1, Name = "Airport1", Longitude = 33.132, Latitude = -6.132 };
            IEnumerable<Flight> flights = new List<Flight> { new Flight { Id = 1 ,From = airport,To=airport,Airplane = airplane} };
            _unitOfWorkMock.Setup(uof => uof.FlightRepository.GetAsync(It.IsAny<Expression<Func<Flight, bool>>>(), It.IsAny<Func<IQueryable<Flight>, IOrderedQueryable<Flight>>>(), It.IsAny<string>())).Returns(Task.FromResult(flights));

            // Act
            var result = await _flightsController.Detail(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<FlightDetailViewModel>(viewResult.Model);

            _unitOfWorkMock.Verify(uof => uof.FlightRepository.GetAsync(It.IsAny<Expression<Func<Flight, bool>>>(), It.IsAny<Func<IQueryable<Flight>, IOrderedQueryable<Flight>>>(), It.IsAny<string>()), Times.Once);
            _distanceCalculatorMock.Verify(calculator => calculator.GetDistance(It.IsAny<Flight>()));
            _keroseneCalculatorMock.Verify(calculator => calculator.GetKeroseneQuantity(It.IsAny<Flight>(),It.IsAny<double>()));
        }
    }
}
