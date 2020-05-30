using FlightManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Helpers
{
    public static class KeroseneCalculatorExtension
    {
        public static double GetKeroseneQuantity(this Flight flight)
        {
            // this may seem simple but it give us flixibility to change it later
            var distance = flight.GetDistance();

            return distance * flight.Airplane.KeroseneConsumption;
        }
    }
}
