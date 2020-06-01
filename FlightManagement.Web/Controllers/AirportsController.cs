using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManagement.Domain.Entities;
using FlightManagement.Domain.Interfaces;
using FlightManagement.Web.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.Web.Controllers
{
    public class AirportsController : Controller
    {
        private IUnitOfWork _unitOfWork;

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
            //TODO: use automapper and remove this code from here
            var newAiroport = new Airport
            {
                Name = model.Name,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
            _unitOfWork.AirportRepository.Add(newAiroport);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }


    }
}