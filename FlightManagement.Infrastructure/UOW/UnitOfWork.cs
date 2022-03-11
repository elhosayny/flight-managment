using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace FlightManagement.Infrastructure.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private Repository<Flight> _flightRepository;
    private Repository<Airplane> _airplaneRepository;
    private Repository<Airport> _airportRepository;

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
                _flightRepository = new Repository<Flight>(_context);
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
                _airplaneRepository = new Repository<Airplane>(_context);
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
                _airportRepository = new Repository<Airport>(_context);
            }
            return _airportRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}