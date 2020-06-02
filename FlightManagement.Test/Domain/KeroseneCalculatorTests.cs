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
        [InlineData(-7.5694, 33.5849, -6.8406, 34.0048,7, 573.65)] // Casablanca -> Rabat
        [InlineData(-5.0132, 34.0109, -7.9759, 31.6625,5, 1902.5)] // Fex -> Marrakech
        [InlineData(-5.8328, 35.7550, -17.0880, 20.8590,10, 19859.3)] // Tanger -> Laguera
        public void GetKeroseneQuantity_ShouldReturnCorrectQuantity(double long1, double lat1, double long2, double lat2, double keroseneConsumption,double expected)
        {
            var airplane = new Airplane { KeroseneConsumption = keroseneConsumption };
            var airport1 = new Airport
            {
                Longitude = long1,
                Latitude = lat1,
            };

            var airport2 = new Airport
            {
                Longitude = long2,
                Latitude = lat2,
            };

            var flight = new Flight
            {
                From = airport1,
                To = airport2,
                Airplane = airplane
            };

            var keroseneCalculator = new KeroseneCalculator();
            var distanceCalculator = new DistanceCalculator();
            var distance = distanceCalculator.GetDistance(flight);
            var actual = keroseneCalculator.GetKeroseneQuantity(flight,distance);

            Assert.Equal(expected, actual);
        }
    }
}
