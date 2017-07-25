using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    class Ferrari : ICar
    {
        public string Model { get; set; }
        public string Driver { get; set; }

        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }
        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
        }
    }
}