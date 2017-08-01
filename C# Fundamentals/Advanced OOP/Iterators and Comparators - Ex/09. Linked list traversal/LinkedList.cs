using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T> where T : IComparable
{
    public LinkedList()
    {
        this.Head = null;
        this.Count = 0;
    }

    private Node<T> Head { get; set; }
    public int Count { get; private set; }

    public void Add(T item)
    {
        if (this.Count == 0)
        {
            this.Head = new Node<T>(item);
        }
        else
        {
            Node<T> lastNode = GetElementAtIndex(this.Count - 1);
            lastNode.Next = new Node<T>(item);
        }

        this.Count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;

        while (currentNode != null)
        {
            yield return currentNode.Value;

            currentNode = currentNode.Next;
        }
    }

    public T Remove(int index)
    {
        var removeValue = default(T);

        if (index == 0)
        {
            removeValue = this.Head.Value;
            this.Head = this.Head.Next;
        }
        else
        {
            Node<T> prevNode = this.GetElementAtIndex(index - 1);
            Node<T> currentNode = this.GetElementAtIndex(index);
            prevNode.Next = currentNode.Next;

            removeValue = currentNode.Value;
        }

        this.Count--;

        return removeValue;
    }

    public int FirstIndexOf(T element)
    {
        int firstIndex = IndexOf(element, true);
        return firstIndex;
    }

    public int LastIndexOf(T element)
    {
        int lastIndex = IndexOf(element, false);
        return lastIndex;
    }

    private int IndexOf(T element, bool isFirstFoundIndexNeeded)
    {
        int foundIndex = -1;
        var currentNode = this.Head;
        for (int index = 0; index < this.Count; index++)
        {
            if (currentNode.Value.Equals(element))
            {
                foundIndex = index;
                if (isFirstFoundIndexNeeded)
                {
                    return foundIndex;
                }
            }

            currentNode = currentNode.Next;
        }

        return foundIndex;
    }

    private Node<T> GetElementAtIndex(int index)
    {
        var currentElement = this.Head;
        for (int i = 0; i < index; i++)
        {
            currentElement = currentElement.Next;
        }

        return currentElement;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}