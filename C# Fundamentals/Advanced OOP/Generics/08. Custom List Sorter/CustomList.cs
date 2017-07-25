using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    public class CustomList<T> where T : IComparable<T>
    {
        public List<T> _items;

        public CustomList()
        {
            _items = new List<T>();
        }
       
        public void Add(T element)
        {
            _items.Add(element);
        }

        public T Remove(int index)
        {
            T reminder = _items.ElementAt(index);
            _items.RemoveAt(index);
            return reminder;
        }

        public bool Contains(T element)
        {
            if (_items.Contains(element))
            {
                return true;
            }
            return false;
        }

        public void Swap(int index1, int index2)
        {
            T reminder1 = _items.ElementAt(index1);
            T reminder2 = _items.ElementAt(index2);
            _items[index1] = reminder2;
            _items[index2] = reminder1;
        }

        public int CountGreaterThan(T element)
        {
            return _items.Count(x => x.CompareTo(element) > 0);
        }

        public T Max()
        {
            return _items.Max();
        }

        public T Min()
        {
            return _items.Min();
        }

        public void Print()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
