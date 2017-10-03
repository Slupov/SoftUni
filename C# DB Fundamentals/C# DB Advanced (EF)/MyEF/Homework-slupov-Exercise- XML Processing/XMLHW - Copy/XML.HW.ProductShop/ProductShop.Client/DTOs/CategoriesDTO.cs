using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Client.DTOs
{
    public class CategoriesDTO
    {
        [XmlArrayItem("category")]
        [XmlArray("categories")]
        public List<CategoryDTO> Categories { get; set; }
    }
}
