using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private readonly ParkingContext _context;

        public VehicleRepository(ParkingContext context)
        {
            _context = context;
        }

        public Vehicle Get(int id)
        {
            return _context.Vehicles.Find(id);
        }

        public ICollection<Vehicle> GetAll()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle Create(Vehicle entity)
        {
            _context.Vehicles.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Vehicle Update(Vehicle entity)
        {
            _context.Vehicles.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Vehicle entity)
        {
            _context.Vehicles.Remove(entity);
            _context.SaveChanges();
        }
    }
 
}
