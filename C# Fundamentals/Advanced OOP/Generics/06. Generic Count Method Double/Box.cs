using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    class Box<T>
    {
        public List<T> list = new List<T>();
        private T value;
        public Box(T value)
        {
            this.value = value;
            this.list = new List<T>();
        }

        public override string ToString()
        {
            return typeof(T).FullName + $": {this.value}";
        }

        public void SwapElements<T>(List<T> elements, int index1, int index2)
        {
            T rem1 = elements[index1];
            T rem2 = elements[index2];
            elements[index1] = rem2;
            elements[index2] = rem1;
        }
        
    }
}
