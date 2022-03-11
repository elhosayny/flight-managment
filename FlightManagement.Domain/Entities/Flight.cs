using FlightManagement.Domain.Common;
using FlightManagement.Domain.Interfaces;
using System;

namespace FlightManagement.Domain.Entities
{
    public class Flight : Entity, IAggregate
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public Airplane Airplane { get; set; }

        public double GetDistance()
        {
            const double EARTH_RADUIS = 6371.0;
            const double DEGREES_TO_RADIANS = (Math.PI / 180.0);

            var fromLatitudeInRadian = From.Latitude * DEGREES_TO_RADIANS; ;
            var toLatitudeInRadian = To.Latitude * DEGREES_TO_RADIANS;

            var deltaLatitude = (To.Latitude - From.Latitude) * DEGREES_TO_RADIANS;
            var deltaLongitude = (To.Longitude - From.Longitude) * DEGREES_TO_RADIANS;

            var a = Math.Pow(Math.Sin(deltaLatitude / 2.0), 2.0) +
                  Math.Cos(fromLatitudeInRadian) * Math.Cos(toLatitudeInRadian) *
                  Math.Pow(Math.Sin(deltaLongitude / 2.0), 2.0);

            var distance = EARTH_RADUIS * 2.0 *
                  Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            return Math.Round(distance, 2);
        }

        public double GetKeroseneQuantity()
        {
            return GetDistance() * Airplane.KeroseneConsumption;
        }
    }
}
