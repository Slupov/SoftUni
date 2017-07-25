using System;

public class Scale<T> where T : IComparable<T>
{
    public T Left { get; set; }
    public T Right { get; set; }
    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T GetHavier()
    {
        if (Left.CompareTo(Right) == 0)
        {
            return default(T);
        }
        else if (Left.CompareTo(Right) < 0)
        {
            return Right;
        }
        else
        {
            return Left ;
        }
    }
}