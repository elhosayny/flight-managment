using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FlightManagement.Test.Domain
{
    public class KeroseneCalculatorTests
    {
        // TODO: Refactor the KeroseneCalculator so that we can unit test it without DistanceCalculator
        [Theory]
        [InlineData(81.95, 7, 573.65)] // Casablanca -> Rabat
        [InlineData(380.5, 5, 1902.5)] // Fex -> Marrakech
        [InlineData(1985.93, 10, 19859.3)] // Tanger -> Laguera
        public void GetKeroseneQuantity_ShouldReturnCorrectQuantity(double distance, double keroseneConsumption,double expected)
        {
            var airplane = new Airplane { KeroseneConsumption = keroseneConsumption };

            var flight = new Flight
            {
                Airplane = airplane
            };

            var keroseneCalculator = new KeroseneCalculator();
            var actual = keroseneCalculator.GetKeroseneQuantity(flight,distance);

            Assert.Equal(expected, actual);
        }
    }
}
