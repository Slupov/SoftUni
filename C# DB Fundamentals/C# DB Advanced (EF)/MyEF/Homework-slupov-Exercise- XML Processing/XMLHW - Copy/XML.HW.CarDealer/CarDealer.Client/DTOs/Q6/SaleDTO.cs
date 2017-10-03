using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CarDealer.Client.DTOs.Q4;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q6
{
    public class SaleDTO
    {
        [XmlElement("car")]
        public CarDTOq6 car { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("discount")]
        public double Discount { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public double PriceWithDiscount { get; set; }
    }
}