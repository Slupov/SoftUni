using _04.Froggy;
using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var stones = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        Lake lake = new Lake(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}