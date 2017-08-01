using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> collection;
    private int currentIndex;

    public ListyIterator(IEnumerable<T> collection)
    {
        this.Reset();
        this.collection = new List<T>(collection);
    }

    private void Reset()
    {
        this.currentIndex = 0;
    }

    public bool Move()
    {
        if (this.currentIndex + 1 < this.collection.Count)
        {
            ++this.currentIndex;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return this.currentIndex < this.collection.Count - 1;
    }

    public void Print()
    {
        if (!this.collection.Any() || this.currentIndex >= this.collection.Count)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.collection[this.currentIndex]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.collection)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}