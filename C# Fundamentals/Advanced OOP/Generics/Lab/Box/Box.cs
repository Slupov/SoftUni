using System.Collections.Generic;

public class Box<T>
{
    public int Count { get; private set; }
    public List<T> items { get; set; }

    public Box()
    {
        this.items = new List<T>();
    }

    public string Add(T element)
    {
        items.Add(element);
        Count++;
        return element.ToString();
    }

    public T Remove()
    {
        T rem = items[items.Count - 1];
        Count--;
        items.RemoveAt(items.Count - 1);
        return rem;
    }
}