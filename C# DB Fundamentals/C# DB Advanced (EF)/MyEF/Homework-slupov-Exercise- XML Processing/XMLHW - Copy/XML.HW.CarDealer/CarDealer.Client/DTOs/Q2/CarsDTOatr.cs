using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q2
{
    public class CarsDTOatr
    {
        [XmlArray("cars")]
        [XmlArrayItem("car")]
        public List<CarDTOatr> Cars { get; set; }
    }
}