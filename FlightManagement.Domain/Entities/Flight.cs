using FlightManagement.Domain.Common;
using FlightManagement.Domain.Interfaces;
using System;

namespace FlightManagement.Domain.Entities;

public class Flight : Entity, IAggregate
{
    public Airport From { get; set; }
    public Airport To { get; set; }
    public Airplane Airplane { get; set; }

    public double GetDistance()
    {
        const double earthRadius = 6371.0;
        const double degreesToRadians = (Math.PI / 180.0);

        var fromLatitudeInRadian = From.Latitude * degreesToRadians; ;
        var toLatitudeInRadian = To.Latitude * degreesToRadians;

        var deltaLatitude = (To.Latitude - From.Latitude) * degreesToRadians;
        var deltaLongitude = (To.Longitude - From.Longitude) * degreesToRadians;

        var a = Math.Pow(Math.Sin(deltaLatitude / 2.0), 2.0) +
                Math.Cos(fromLatitudeInRadian) * Math.Cos(toLatitudeInRadian) *
                Math.Pow(Math.Sin(deltaLongitude / 2.0), 2.0);

        var distance = earthRadius * 2.0 *
                       Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

        return Math.Round(distance, 2);
    }

    public double GetKeroseneQuantity()
    {
        return GetDistance() * Airplane.KeroseneConsumption;
    }
}