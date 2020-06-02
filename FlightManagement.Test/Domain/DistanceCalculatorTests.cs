using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FlightManagement.Test.Domain
{
    public class DistanceCalculatorTests
    {
        [Theory]
        [InlineData(-7.5694, 33.5849, -6.8406, 34.0048, 81.95)] // Casablanca -> Rabat
        [InlineData(-5.0132, 34.0109, -7.9759, 31.6625, 380.5)] // Fex -> Marrakech
        [InlineData(-5.8328, 35.7550, -17.0880, 20.8590, 1985.93)] // Tanger -> Laguera
        public void GetDistance_ShouldReturnCorrectDistance(double long1,double lat1,double long2,double lat2,double expected)
        {
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
                To = airport2
            };

            var distanceCalculator = new DistanceCalculator();

            var actual = distanceCalculator.GetDistance(flight);

            Assert.Equal(expected, actual);
        }
    }
}
