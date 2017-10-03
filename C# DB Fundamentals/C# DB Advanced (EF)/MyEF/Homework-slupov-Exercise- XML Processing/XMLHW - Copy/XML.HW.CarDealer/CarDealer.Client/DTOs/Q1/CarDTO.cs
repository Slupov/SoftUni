using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q1
{
    public class CarDTO
    {
        [XmlElement("make")]
        public string make { get; set; }

        [XmlElement("model")]
        public string model { get; set; }

        [XmlElement("travelled-distance")]
        public long travelledDistance { get; set; }
    }
}