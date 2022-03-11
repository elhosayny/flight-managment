using FlightManagement.Domain.Entities;
using Xunit;

namespace FlightManagement.Test.Domain
{
    public class KeroseneCalculatorTests
    {
        [Theory]
        [InlineData(7, 573.65)] // Casablanca -> Rabat
        [InlineData(5, 1902.5)] // Fex -> Marrakech
        [InlineData(10, 19859.3)] // Tanger -> Laguera
        public void GetKeroseneQuantity_ShouldReturnCorrectQuantity(double keroseneConsumption, double expected)
        {
            var airplane = new Airplane { KeroseneConsumption = keroseneConsumption };

            var flight = new Flight
            {
                Airplane = airplane
            };
            var actual = flight.GetKeroseneQuantity();
            Assert.Equal(expected, actual);
        }
    }
}
