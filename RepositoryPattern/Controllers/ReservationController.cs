using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.BusinessLogicLayer;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationLogic _reservationLogic;

        public ReservationController(ReservationLogic reservationLogic)
        {
            _reservationLogic = reservationLogic;
        }

        [HttpGet]
        public IActionResult GetReservation(int id)
        {
            var reservation = _reservationLogic.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var reservations = _reservationLogic.GetAllReservations();
            return View(reservations);
        }

        [HttpPost]
        public IActionResult CreateReservation(int parkingSpotId, int vehicleId, DateTime expiry, bool isCurrent)
        {
            var newReservation = _reservationLogic.CreateReservation(parkingSpotId, vehicleId, expiry, isCurrent);
            return View(newReservation);
        }

        [HttpPut]
        public IActionResult UpdateReservation([FromBody] Reservation reservation)
        {
            _reservationLogic.UpdateReservation(reservation);
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            _reservationLogic.DeleteReservation(id);
            return View();
        }
    }
}
