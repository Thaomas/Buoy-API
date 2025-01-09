using System.ComponentModel.DataAnnotations;

namespace Boei_API.Models
{
    public class Buoy
    {
        [Key]
        public Guid ID { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }
        public String DevEUID { get; set; }

        public ICollection<BuoySensor> Sensors { get; set; }
        public ICollection<GPSLocation> Locations { get; set; }


    }
}
