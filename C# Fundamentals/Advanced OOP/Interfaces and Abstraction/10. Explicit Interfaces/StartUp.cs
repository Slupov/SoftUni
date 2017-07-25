
using System;
using System.Collections.Generic;

namespace _10.Explicit_Interface
{
    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();
            List<IPerson> persons = new List<IPerson>();
            List<IResident> residents = new List<IResident>();
            while (input[0] != "End")
            {
                Citizen citizen = new Citizen(input[0],input[1], input[2]);

                persons.Add(citizen);
                residents.Add(citizen);
                input = Console.ReadLine().Split();
            }

            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine(persons[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}
