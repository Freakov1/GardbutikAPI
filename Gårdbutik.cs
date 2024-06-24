namespace GårdbutikAPI.Models
{
    public class Gårdbutik
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Description { get; set; }

        public bool Kartofler { get; set; }

        
    }
}
