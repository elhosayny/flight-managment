using FlightManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Helpers
{
    public static class DistanceCalculatorExtension
    {
        public static double GetDistance(this Flight flight)
        {
            const double EARTH_RADUIS = 6371.0;
            const double DEGREES_TO_RADIANS = (Math.PI / 180.0);
            
            var fromLatitudeInRadian = flight.From.Latitude * DEGREES_TO_RADIANS; ;
            var toLatitudeInRadian = flight.To.Latitude * DEGREES_TO_RADIANS;

            var deltaLatitude = (flight.To.Latitude-flight.From.Latitude) * DEGREES_TO_RADIANS;
            var deltaLongitude = (flight.To.Longitude - flight.From.Longitude) * DEGREES_TO_RADIANS;

            // This formulat does have a name so I called "a" to make it more readable
            var a = Math.Pow(Math.Sin(deltaLatitude / 2.0), 2.0) +
                  Math.Cos(fromLatitudeInRadian) * Math.Cos(toLatitudeInRadian) *
                  Math.Pow(Math.Sin(deltaLongitude / 2.0), 2.0);

            var distance = EARTH_RADUIS * 2.0 *
                  Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            return Math.Round(distance,2);
        }
    }
}
