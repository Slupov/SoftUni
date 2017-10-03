using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q6
{
    public class SalesDTO
    {
        [XmlArray("sales")]
        [XmlArrayItem("sale")]
        public List<SaleDTO> Sales { get; set; }
    }
}