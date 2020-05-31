using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        private BaseRepository<Flight> _flightRepository;
        private BaseRepository<Airplane> _airplaneRepository;
        private BaseRepository<Airport> _airportRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Flight> FlightRepository
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new BaseRepository<Flight>(_context);
                }
                return _flightRepository;
            }
        }
        public IRepository<Airplane> AirplaneRepository
        {
            get
            {
                if (_airplaneRepository == null)
                {
                    _airplaneRepository = new BaseRepository<Airplane>(_context);
                }
                return _airplaneRepository;
            }
        }
        public IRepository<Airport> AirportRepository
        {
            get
            {
                if (_airportRepository == null)
                {
                    _airportRepository = new BaseRepository<Airport>(_context);
                }
                return _airportRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
