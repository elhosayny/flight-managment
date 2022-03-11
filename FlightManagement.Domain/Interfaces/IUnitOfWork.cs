using FlightManagement.Domain.Entities;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Flight> FlightRepository { get;  }
        IRepository<Airplane> AirplaneRepository { get;  }
        IRepository<Airport> AirportRepository { get; }
        Task SaveAsync();
    }
}
