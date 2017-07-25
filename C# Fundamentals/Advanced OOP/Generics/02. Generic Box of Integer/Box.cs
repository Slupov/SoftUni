using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    class Box<T>
    {
        private T value;
        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return typeof(T).FullName + $": {this.value}";
        }
    }
}
