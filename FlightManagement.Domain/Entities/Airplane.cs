using FlightManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Entities
{
    public class Airplane : BaseEntity
    {
        public int KeroseneConsumption { get; set; }
        public int Speed { get; set; }
    }
}
