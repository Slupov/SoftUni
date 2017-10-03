using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProductShop.Data.Models;

namespace ProductShop.Client.DTOs
{
    public class UserDTO
    {
        [XmlAttribute("first-name")]
        public string firstName { get; set; }

        [XmlAttribute("last-name")]
        public string lastName { get; set; }

        [XmlAttribute("age")]
        public int? age { get; set; }


    }
}
