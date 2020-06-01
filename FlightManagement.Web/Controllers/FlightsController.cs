using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Infrastructure.UOW;
using FlightManagement.Web.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Web.Controllers
{
    public class FlightsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public FlightsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var flights = await _unitOfWork.FlightRepository.GetAsync(includeProperties:"From,To,Airplane");
            return View(flights);
        }

        public async Task<IActionResult> Create()
        {
            _unitOfWork.AirportRepository.Add(new Airport() { Name = "Casablanca" });
            _unitOfWork.AirportRepository.Add(new Airport() { Name = "Marakech" });
            _unitOfWork.AirportRepository.Add(new Airport() { Name = "Tetouan" });
            await _unitOfWork.SaveAsync();
            _unitOfWork.AirplaneRepository.Add(new Airplane() { Name = "Boeing 787" });
            _unitOfWork.AirplaneRepository.Add(new Airplane() { Name = "Lockheed SR-71 Blackbird" });
            _unitOfWork.AirplaneRepository.Add(new Airplane() { Name = "Cirrus SR22" });
            await _unitOfWork.SaveAsync();

            var airports = await _unitOfWork.AirportRepository.GetAllAsync();
            var airplanes = await _unitOfWork.AirplaneRepository.GetAllAsync();
            ViewBag.Airports = airports;
            ViewBag.Airplanes = airplanes;
            return View();
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
}