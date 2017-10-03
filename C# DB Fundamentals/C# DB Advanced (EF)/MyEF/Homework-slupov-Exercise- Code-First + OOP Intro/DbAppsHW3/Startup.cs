using System;
using System.Linq;

namespace DbAppsHW3
{
    class Startup
    {
        static void Main(string[] args)
        {
//            Exercises1and2();
//            Exercise3();
//            Exercise4();
//            Exercise5();
//            Exercise6();
        }

        static Person createHumanByInput()
        {
            string[] input = Console.ReadLine().Split(new char[] {',', ' '}).ToArray();
            var paramCount = input.Length;

            switch (paramCount)
            {
                case 1:
                    //in case of no arguments
                    if (input[0] == "")
                    {
                        return new Person();
                    }
                    int age;
                    bool isNum = int.TryParse(input[0], out age);

                    //if parameter is string
                    if (isNum == false)
                    {
                        return new Person(input[0]);
                    }
                    else
                    {
                        return new Person(age);
                    }
                    break;
                case 2:
                    bool isNum1 = int.TryParse(input[0], out age);
                    bool isNum2 = int.TryParse(input[1], out age);

                    if ((isNum2 && isNum1) && (isNum2 || isNum1 == false))
                    {
                        throw new Exception("No such Person constructor");
                    }
                    if (isNum1 && !isNum2)
                    {
                        int.TryParse(input[0], out age);
                        return new Person(input[1], age);
                    }
                    else if (isNum2 && !isNum1)
                    {
                        return new Person(input[0], age);
                    }
                    break;
            }

            //if there are more than 2 arguments (no info in assignment => default constructor)
            return new Person();
        }

        static void Exercises1and2()
        {
            Person human = createHumanByInput();
            Console.WriteLine(human);
        }

        static void Exercise3()
        {
            int n = int.Parse(Console.ReadLine());
            Family fam = new Family();

            for (int i = 0; i < n; i++)
            {
                fam.AddMember(createHumanByInput());
            }

            Console.WriteLine(fam.GetOldersMember());
        }

        static void Exercise4()
        {
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                Student newStudent = new Student(cmd);
                cmd = Console.ReadLine();
            }

            Console.WriteLine(Student.StudentsCreated);
        }

        static void Exercise5()
        {
            Console.WriteLine(Calculation.reducedPc);
        }

        static void Exercise6()
        {
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] tokens = cmd.Split(' ').ToArray();
                if (tokens.Length != 3)
                {
                    Console.WriteLine("Incorrect number of parameters! Try again...");
                    cmd = Console.ReadLine();
                    continue;
                }
                switch (tokens[0])
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.Sum(double.Parse(tokens[1]), double.Parse(tokens[2])):F2}");
                        break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.Subtract(double.Parse(tokens[1]), double.Parse(tokens[2])):F2}");
                        break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.Multiply(double.Parse(tokens[1]), double.Parse(tokens[2])):F2}");
                        break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.Divide(double.Parse(tokens[1]), double.Parse(tokens[2])):F2}");
                        break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.Percentage(double.Parse(tokens[1]), double.Parse(tokens[2])):F2}");
                        break;
                    default:
                        Console.WriteLine("Incorrect parameters! Try again...");
                        break;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}