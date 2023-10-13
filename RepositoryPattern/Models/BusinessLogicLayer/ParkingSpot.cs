using RepositoryPattern.Data;

namespace RepositoryPattern.Models.BusinessLogicLayer
{
    public class ParkingSpotLogic
    {
        private readonly IRepository<ParkingSpot> _parkingSpotRepository;

        public ParkingSpotLogic(IRepository<ParkingSpot> parkingSpotRepository)
        {
            _parkingSpotRepository = parkingSpotRepository;
        }

        public ParkingSpot GetParkingSpot(int id)
        {
            return _parkingSpotRepository.Get(id);
        }

        public ICollection<ParkingSpot> GetAllParkingSpots()
        {
            return _parkingSpotRepository.GetAll();
        }

        public ParkingSpot CreateParkingSpot()
        {
            ParkingSpot newSpot = new ParkingSpot
            {
                Occupied = false
            };

            _parkingSpotRepository.Create(newSpot);

            return newSpot;
        }

        public ParkingSpot UpdateParkingSpot(ParkingSpot spot)
        {
            _parkingSpotRepository.Update(spot);
            return spot;
        }

        public void DeleteParkingSpot(int spotId)
        {
            ParkingSpot spot = _parkingSpotRepository.Get(spotId);
            if (spot != null)
            {
                _parkingSpotRepository.Delete(spot);
            }
        }
    }

}
