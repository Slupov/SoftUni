using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.Client.DTOs
{
    public class UsersDTO
    {
        [XmlArrayItem("user")]
        [XmlArray("users")]
        public List<UserDTO> Users { get; set; }
    }
}
