using GårdbutikAPI.Models;
using System;

namespace GårdbutikAPI.Managers
{
    public class GårdbutikManagerDB
    {
        private GårdbutikContext _context;

        public GårdbutikManagerDB(GårdbutikContext context)
        {
            _context = context;
        }

        public Gårdbutik Add(Gårdbutik newgård)
        {
            
            _context.Gårdbutik.Add(newgård);
            _context.SaveChanges();
            return newgård;
        }

        public Gårdbutik? Delete(int Id)
        {
            Gårdbutik? foundshop = GetById(Id);

            if (foundshop != null)
            {
                _context.Gårdbutik.Remove(foundshop);
                _context.SaveChanges();
            }
            return foundshop;
        }

        public Gårdbutik? GetById(int Id)
        {
            return _context.Gårdbutik.FirstOrDefault(shop => shop.Id == Id);
        }

        public IEnumerable<Gårdbutik> GetAll()
        {
            return _context.Gårdbutik;
        }

        public Gårdbutik? Update(int Id, Gårdbutik updates)
        {
            Gårdbutik shopToBeUpdated = GetById(Id);
            shopToBeUpdated.Name = updates.Name;
            shopToBeUpdated.Description = updates.Description;

            _context.SaveChanges();

            return shopToBeUpdated;
        }
    }
}
