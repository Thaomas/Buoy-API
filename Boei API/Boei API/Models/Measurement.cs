namespace Boei_API.Models
{
    public class Measurement
    {
        public Guid ID { get; }
        public Guid BuoySensorID { get; set; }
        public DateTime Timestamp { get; set; }
        public Double Value { get; set; }

        public BuoySensor Sensor { get; set; }
    }
}
