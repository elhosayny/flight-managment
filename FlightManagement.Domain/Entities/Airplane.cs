using FlightManagement.Domain.Common;
using FlightManagement.Domain.Interfaces;

namespace FlightManagement.Domain.Entities
{
    public class Airplane : Entity, IAggregate
    {
        public string Name { get; set; }
        public double KeroseneConsumption { get; set; }
        public double Speed { get; set; }
    }
}
