using FlightManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Flight> FlightRepository { get;  }
        IRepository<Airplane> AirplaneRepository { get;  }
        IRepository<Airport> AirportRepository { get; }
        Task Save();
    }
}
