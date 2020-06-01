using FlightManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Entities
{
    public class Airplane : BaseEntity
    {
        public string Name { get; set; }
        public double KeroseneConsumption { get; set; }
        public double Speed { get; set; }
    }
}
