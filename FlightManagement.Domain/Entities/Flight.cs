using FlightManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Entities
{
    public class Flight : BaseEntity
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public Airplane Airplane { get; set; }
    }
}
