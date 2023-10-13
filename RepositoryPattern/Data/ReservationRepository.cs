using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly ParkingContext _context;

        public ReservationRepository(ParkingContext context)
        {
            _context = context;
        }

        public Reservation Get(int id)
        {
            return _context.Reservations.Find(id);
        }

        public ICollection<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public Reservation Create(Reservation entity)
        {
            _context.Reservations.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Reservation Update(Reservation entity)
        {
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            _context.SaveChanges();
        }
    }

}
