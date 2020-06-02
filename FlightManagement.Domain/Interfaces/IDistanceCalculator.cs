using FlightManagement.Domain.Entities;

namespace FlightManagement.Domain.Interfaces
{
    public interface IDistanceCalculator
    {
        double GetDistance(Flight flight);
    }
}