using GårdbutikAPI.Models;

namespace GårdbutikAPI.Managers
{
    public class GårdbutikManager
    {
        private int _nextId = 1;
        private readonly List<Gårdbutik> Data;

        public GårdbutikManager()
        {
            Data = new List<Gårdbutik>
            {
                new Gårdbutik {Id = _nextId++, Name = "C# is nice", Description = "hej"},
                new Gårdbutik {Id = _nextId++, Name = "C# isss nice", Description = "heaaaaj"},
                
               
            };
        }

        public List<Gårdbutik> GetAll()
        {
            return new List<Gårdbutik>(Data);
            
        }

        public Gårdbutik? GetById(int Id)
        {
            return Data.Find(Gårdbutik => Gårdbutik.Id == Id);
        }

        public Gårdbutik Add(Gårdbutik newGårdbutik)
        {
            
            newGårdbutik.Id = _nextId++;
            Data.Add(newGårdbutik);
            return newGårdbutik;
        }

        public Gårdbutik? Update(int Id, Gårdbutik updates)
        {
            
            Gårdbutik? oldGårdbutik = GetById(Id);
            if (oldGårdbutik == null) return null;
            oldGårdbutik.Name = updates.Name;
            oldGårdbutik.Description = updates.Description;
            return oldGårdbutik;
        }

        public Gårdbutik? Delete(int Id)
        {
            Gårdbutik? toBeDeleted = GetById(Id);
            if (toBeDeleted == null) return null;
            Data.Remove(toBeDeleted);
            return toBeDeleted;
        }
    }
}
