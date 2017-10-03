using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Client.DTOs.Q3
{
    public class SuppliersDTO
    {
        [XmlArray("suppliers")]
        [XmlArrayItem("supplier")]
        public List<SupplierDTO> suppliers { get; set; }
    }
}
