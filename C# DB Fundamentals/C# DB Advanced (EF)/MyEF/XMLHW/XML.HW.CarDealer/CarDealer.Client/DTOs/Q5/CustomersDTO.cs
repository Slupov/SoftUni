using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q5
{
    public class CustomersDTO
    {
        [XmlArray("customers")]
        [XmlArrayItem("customer")]
        public List<CustomerDTO> Customers { get; set; }
    }
}
