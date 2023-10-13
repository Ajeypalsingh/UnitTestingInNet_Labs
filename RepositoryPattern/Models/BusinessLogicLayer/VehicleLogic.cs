using RepositoryPattern.Data;

namespace RepositoryPattern.Models.BusinessLogicLayer
{
    public class VehicleLogic
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        public VehicleLogic(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle GetVehicle(int id)
        {
            return _vehicleRepository.Get(id);
        }

        public ICollection<Vehicle> GetAllVehicles()
        {
            return _vehicleRepository.GetAll();
        }

        public Vehicle CreateVehicle(int passId)
        {
            Vehicle newVehicle = new Vehicle
            {
                PassID = passId,
                Parked = false
            };

            _vehicleRepository.Create(newVehicle);

            return newVehicle;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }

        public void DeleteVehicle(int vehicleId)
        {
            Vehicle vehicle = _vehicleRepository.Get(vehicleId);
            if (vehicle != null)
            {
                _vehicleRepository.Delete(vehicle);
            }
        }
    }

}
