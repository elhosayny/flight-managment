using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Helpers
{
    public class KeroseneCalculator : IKeroseneCalculator
    {
        public double GetKeroseneQuantity(Flight flight, double distance)
        {
            // this may seem simple but it give us flixibility to change it later

            return distance * flight.Airplane.KeroseneConsumption;
        }
    }
}
