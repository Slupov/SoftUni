using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Client.DTOs
{
    public class ProductsDTO
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlArrayItem("product")]
        public List<ProductDTO> Products { get; set; }
    }
}