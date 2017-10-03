using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q4
{
    public class CarDTOq4
    {
        [XmlAttribute("make")]
        public string make { get; set; }

        [XmlAttribute("model")]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long travelledDistance { get; set; }

        [XmlArray("parts")]
        [XmlArrayItem("part")]
        public List<PartDTO> parts { get; set; }
    }
}