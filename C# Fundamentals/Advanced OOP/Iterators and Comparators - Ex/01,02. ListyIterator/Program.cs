using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string input = string.Empty;

        ListyIterator<string> listy = null;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Create":
                        listy = new ListyIterator<string>(tokens.Skip(1));
                        break;

                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;

                    case "Print":
                        listy.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;

                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", listy));
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}