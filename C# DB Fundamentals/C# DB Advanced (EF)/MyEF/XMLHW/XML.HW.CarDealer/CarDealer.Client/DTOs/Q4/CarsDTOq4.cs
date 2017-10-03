using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q4
{
    public class CarsDTOq4
    {
        [XmlArray("cars")]
        [XmlArrayItem("car")]
        public List<CarDTOq4> Cars { get; set; }
    }
}
