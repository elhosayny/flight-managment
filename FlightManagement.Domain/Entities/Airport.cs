using FlightManagement.Domain.Common;
using FlightManagement.Domain.Interfaces;

namespace FlightManagement.Domain.Entities
{
    public class Airport : Entity, IAggregate
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
