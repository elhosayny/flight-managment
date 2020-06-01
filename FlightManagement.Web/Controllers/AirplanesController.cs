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
    public class AirplanesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public AirplanesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var airplanes = await _unitOfWork.AirplaneRepository.GetAllAsync();
            return View(airplanes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirplaneViewModel model)
        {
            //TODO: use automapper and remove this code from here
            var newAirplane = new Airplane
            {
                Name = model.Name,
                KeroseneConsumption = model.KeroseneConsumption,
                Speed = model.Speed
            };

            _unitOfWork.AirplaneRepository.Add(newAirplane);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}