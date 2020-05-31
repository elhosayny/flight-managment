using FlightManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagement.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Flight> FlightRepository { get; set; }
        IRepository<Airplane> AirplaneRepository { get; set; }
        IRepository<Airport> AirportRepository { get; set; }
        void Save();
    }
}
