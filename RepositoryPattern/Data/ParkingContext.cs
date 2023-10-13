using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System.Collections.Generic;

namespace RepositoryPattern.Data
{
    public class ParkingContext : DbContext
    {
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<ParkingSpot> ParkingSpots { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}
