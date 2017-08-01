using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class StackOfStrings
    {
        private List<string> data;

        public StackOfStrings()
        {
            data = new List<string>();
        }
        public void Push(string item)
        {
            data.Add(item);
        }

        public string Pop()
        {
            var toreturn = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return toreturn;
        }

        public string Peek()
        {
            var toreturn = data[data.Count - 1];
            return toreturn;
        }

        public bool IsEmpty()
        {
            return data.Any();
        }

    }
