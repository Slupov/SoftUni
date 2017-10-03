using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q4
{
    public class PartDTO
    {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("price")]
        public decimal price { get; set; }
    }
}