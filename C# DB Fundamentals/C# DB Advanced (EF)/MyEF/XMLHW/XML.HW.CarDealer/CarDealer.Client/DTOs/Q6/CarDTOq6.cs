using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarDealer.Client.DTOs.Q4;

namespace CarDealer.Client.DTOs.Q6
{
    public class CarDTOq6
    {
        [XmlAttribute("make")]
        public string make { get; set; }

        [XmlAttribute("model")]
        public string model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long travelledDistance { get; set; }
    }
}