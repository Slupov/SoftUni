using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Smartphone
{
    public interface ISmartphone : IPhone
    {
        string Browse(string website);
    }
}
