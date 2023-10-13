using RepositoryPattern.Data;

namespace RepositoryPattern.Models.BusinessLogicLayer
{
    public class ReservationLogic
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationLogic(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation GetReservation(int id)
        {
            return _reservationRepository.Get(id);
        }

        public ICollection<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAll();
        }

        public Reservation CreateReservation(int parkingSpotId, int vehicleId, DateTime expiry, bool isCurrent)
        {
            Reservation newReservation = new Reservation
            {
                ParkingSpotID = parkingSpotId,
                VehicleID = vehicleId,
                Expiry = expiry,
                IsCurrent = isCurrent
            };

            _reservationRepository.Create(newReservation);

            return newReservation;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
            return reservation;
        }

        public void DeleteReservation(int reservationId)
        {
            Reservation reservation = _reservationRepository.Get(reservationId);
            if (reservation != null)
            {
                _reservationRepository.Delete(reservation);
            }
        }
    }

}
