using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Smartphone
{
    class Smartphone : ISmartphone
    {
        public string Call(string number)
        {
            if (!TestNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }

        public string Browse(string website)
        {
            if (!TestUrl(website))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {website}!";
        }

        public bool TestNumber(string number)
        {
            if (number.Any(x => x < 48 || x > 57))
            {
                return false;
            }
            return true;
        }

        public bool TestUrl(string url)
        {
            if (url.Any(x => x >= 48 && x <= 57))
            {
                return false;
            }
            return true;
        }
    }
}
