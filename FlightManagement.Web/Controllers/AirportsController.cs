using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Web.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Web.Controllers;

public class AirportsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AirportsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> Index()
    {
        var airports = await _unitOfWork.AirportRepository.GetAllAsync();
        return View(airports);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AirportViewModel model)
    {
        var newAirport = new Airport
        {
            Name = model.Name,
            Latitude = model.Latitude,
            Longitude = model.Longitude
        };
        _unitOfWork.AirportRepository.Add(newAirport);
        await _unitOfWork.SaveAsync();

        return RedirectToAction("Index");
    }


}