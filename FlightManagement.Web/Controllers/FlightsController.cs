using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Web.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Web.Controllers;

public class FlightsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public FlightsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> Index()
    {
        var flights = await _unitOfWork.FlightRepository.GetAsync(includeProperties: "From,To,Airplane");
        return View(flights);
    }

    public async Task<IActionResult> Create()
    {
        var airports = await _unitOfWork.AirportRepository.GetAllAsync();
        var airplanes = await _unitOfWork.AirplaneRepository.GetAllAsync();
        ViewBag.Airports = airports;
        ViewBag.Airplanes = airplanes;
        return View();
    }

    public async Task<IActionResult> Detail(int id)
    {
        var result = await _unitOfWork.FlightRepository.GetAsync(f=>f.Id == id,includeProperties:"To,From,Airplane");
        try
        {
            var flight = result.SingleOrDefault();

            if (flight == null)
            {
                return BadRequest();
            }

            var distance = flight.GetDistance();
            var keroseneQuantity = flight.GetKeroseneQuantity();
            var model = new FlightDetailViewModel
            {
                From = flight.From.Name,
                To = flight.To.Name,
                Distance = distance,
                KeroseneQuantity = keroseneQuantity
            };

            return View(model);
        }
        catch (InvalidOperationException)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FlightViewModel model)
    {
        var from = await _unitOfWork.AirportRepository.GetByIdAsync(model.FromAirportId);
        var to = await _unitOfWork.AirportRepository.GetByIdAsync(model.ToAirportId);
        var airplane = await _unitOfWork.AirplaneRepository.GetByIdAsync(model.AirplaneId);

        var newFlight = new Flight
        {
            From = from,
            To = to,
            Airplane = airplane
        };
        _unitOfWork.FlightRepository.Add(newFlight);

        await _unitOfWork.SaveAsync();
        return RedirectToAction("Index");
    }
}