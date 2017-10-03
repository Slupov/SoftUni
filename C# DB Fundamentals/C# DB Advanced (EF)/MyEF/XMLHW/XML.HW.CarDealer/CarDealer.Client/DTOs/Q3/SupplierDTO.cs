using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q3
{
    public class SupplierDTO
    {
        [XmlAttribute("id")]
        public int id { get; set; }

        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("parts-count")]
        public int partsCount { get; set; }
    }
}
