using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Web.Controllers;
using FlightManagement.Web.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FlightManagement.Test.Controllers
{
    public class AirplaneControllerTest
    {
        private AirplanesController _airplanesController;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        public AirplaneControllerTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _airplanesController = new AirplanesController(_unitOfWorkMock.Object);
        }
        [Fact]
        public async Task Index_ShouldReturnsAirplanes()
        {
            // Arrange
            IEnumerable<Airplane> airplane = new List<Airplane>();
            _unitOfWorkMock.Setup(uof => uof.AirplaneRepository.GetAllAsync()).Returns(Task.FromResult(airplane));


            // Act
            var result = await _airplanesController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Airplane>>(viewResult.Model);
            _unitOfWorkMock.Verify(uof => uof.AirplaneRepository.GetAllAsync());
        }

        [Fact]
        public async Task Create_ShouldCreateNewAirplane()
        {
            // Arrange
            var viewModel = new AirplaneViewModel()
            {
                Name = "Name1",
                KeroseneConsumption = 6,
                Speed = 800
            };

            var airplane = new Airplane()
            {
                Name = "Name1",
                KeroseneConsumption = 6,
                Speed = 800
            };

            _unitOfWorkMock
                .Setup(uof => uof.AirplaneRepository
                    .Add(It.IsAny<Airplane>()));

            // Act
            var result = await _airplanesController.Create(viewModel);

            // Assert

            var redirect = Assert.IsType<RedirectToActionResult>(result);
            _unitOfWorkMock.Verify(uof => uof.AirplaneRepository.Add(It.Is<Airplane>(a => a.Name == airplane.Name &&
                          a.KeroseneConsumption == airplane.KeroseneConsumption &&
                          a.Speed == airplane.Speed)));
        }
    }
}
