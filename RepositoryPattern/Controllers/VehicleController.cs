using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.BusinessLogicLayer;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleLogic _vehicleLogic;

        public VehicleController(VehicleLogic vehicleLogic)
        {
            _vehicleLogic = vehicleLogic;
        }

        [HttpGet]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = _vehicleLogic.GetVehicle(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            var vehicles = _vehicleLogic.GetAllVehicles();
            return View(vehicles);
        }

        [HttpPost]
        public IActionResult CreateVehicle(int passId)
        {
            var newVehicle = _vehicleLogic.CreateVehicle(passId);
            return View(newVehicle);
        }

        [HttpPut]
        public IActionResult UpdateVehicle([FromBody] Vehicle vehicle)
        {
            _vehicleLogic.UpdateVehicle(vehicle);
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteVehicle(int id)
        {
            _vehicleLogic.DeleteVehicle(id);
            return View();
        }
    }

}
