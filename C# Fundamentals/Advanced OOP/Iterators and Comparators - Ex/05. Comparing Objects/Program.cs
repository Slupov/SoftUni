using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = string.Empty;
        List<Person> people = new List<Person>();

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
        }

        int n = int.Parse(Console.ReadLine()) - 1;
        var selected = people[n];

        if (people.Count(x => x.CompareTo(selected) == 0) > 1)
        {
            int equalPeople = people.Count(p => p.CompareTo(selected) == 0);
            int differentPeople = people.Count(p => p.CompareTo(selected) != 0);

            Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}