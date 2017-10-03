using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q2
{
    public class CarDTOatr
    {
        [XmlAttribute("id")]
        public int id { get; set; }

        [XmlAttribute("model")]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long travelledDistance { get; set; }

    }
}