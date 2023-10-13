using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.BusinessLogicLayer;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class ParkingSpotController : Controller
    {
        private readonly ParkingSpotLogic _parkingSpotLogic;

        public ParkingSpotController(ParkingSpotLogic parkingSpotLogic)
        {
            _parkingSpotLogic = parkingSpotLogic;
        }

        [HttpGet]
        public IActionResult GetParkingSpot(int id)
        {
            var parkingSpot = _parkingSpotLogic.GetParkingSpot(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }
            return View(parkingSpot);
        }

        [HttpGet]
        public IActionResult GetAllParkingSpots()
        {
            var parkingSpots = _parkingSpotLogic.GetAllParkingSpots();
            return View(parkingSpots);
        }

        [HttpPost]
        public IActionResult CreateParkingSpot()
        {
            var newSpot = _parkingSpotLogic.CreateParkingSpot();
            return View(newSpot);
        }

        [HttpPut]
        public IActionResult UpdateParkingSpot([FromBody] ParkingSpot spot)
        {
            _parkingSpotLogic.UpdateParkingSpot(spot);
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteParkingSpot(int id)
        {
            _parkingSpotLogic.DeleteParkingSpot(id);
            return View();
        }
    }

}
