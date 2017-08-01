using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    public Stack()
    {
        this.Collection = new List<T>();
    }

    private IList<T> Collection { get; set; }

    public void Push(params T[] input)
    {
        foreach (var item in input)
        {
            this.Collection.Add(item);
        }
    }

    public T Pop()
    {
        if (this.Collection.Count > 0)
        {
            T top = this.Collection.Last();
            this.Collection.Remove(top);
            return top;
        }
        else
        {
            throw new InvalidOperationException("No elements");
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Collection.Count - 1; i >= 0; i--)
        {
            yield return this.Collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}