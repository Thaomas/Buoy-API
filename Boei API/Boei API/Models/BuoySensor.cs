using Microsoft.EntityFrameworkCore;

namespace Boei_API.Models
{
    public class BuoySensor
    {
        public Guid ID { get; }
        public Guid BuoyID { get; set; }
        public Guid SensorTypesID { get; set; }
        public String Status { get; set; }
        public Double LowerLimit { get; set; }
        public Double UpperLimit { get; set; }
        public Double Offset { get; set; }


        public Buoy Buoy { get; set; }
        public SensorType SensorType { get; set; }
        public ICollection<Measurement> Measurements { get; set; }
    }
}
