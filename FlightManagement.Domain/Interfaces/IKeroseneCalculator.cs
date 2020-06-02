using FlightManagement.Domain.Entities;

namespace FlightManagement.Domain.Interfaces
{
    public interface IKeroseneCalculator
    {
        double GetKeroseneQuantity(Flight flight, double distance);
    }
}