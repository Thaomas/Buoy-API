namespace Boei_API.Models
{
    public class GPSLocation
    {
        public Guid ID { get; }
        public Guid BuoyID { get; set; }
        public Double Longitude { get; set; }
        public Double Latitude { get; set; }

        public Buoy Buoy { get; set; }

    }
}
