using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q1
{
    public class CarsDTO
    {
        [XmlArray("cars")]
        [XmlArrayItem("car")]
        public List<CarDTO> Cars { get; set; }
    }
}
