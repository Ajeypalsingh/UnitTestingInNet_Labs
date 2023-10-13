﻿using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class PassRepository : IRepository<Pass>
    {
        private readonly ParkingContext _context;

        public PassRepository(ParkingContext context)
        {
            _context = context;
        }

        public Pass Get(int id)
        {
            return _context.Passes.Find(id);
        }

        public ICollection<Pass> GetAll()
        {
            return _context.Passes.ToList();
        }

        public Pass Create(Pass entity)
        {
            _context.Passes.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Pass Update(Pass entity)
        {
            _context.Passes.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Pass entity)
        {
            _context.Passes.Remove(entity);
            _context.SaveChanges();
        }
    }

}
