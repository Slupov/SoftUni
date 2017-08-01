using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = string.Empty;

        Stack<int> myStack = new Stack<int>();

        while ((input = Console.ReadLine()) != "END")
        {
            List<string> tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = tokens[0];
            int[] numbers = tokens.Skip(1).Select(int.Parse).ToArray();
            try
            {
                switch (command)
                {
                    case "Push":
                        myStack.Push(numbers);
                        break;

                    case "Pop":
                        myStack.Pop();
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        if (myStack.Any())
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join(Environment.NewLine, myStack));
            }
        }
    }
}