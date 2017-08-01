using System;
using System.Collections.Generic;
using System.Linq;

class Engine
{
    private CarManager carManager;
    private bool IsRunning { get; set; }
    public Engine()
    {
        this.carManager = new CarManager();
        IsRunning = true;
    }

    public void Run()
    {
        var tokens = ParseInput(Console.ReadLine());
        string command = string.Empty;

        while ((command = tokens[0]) != "Cops")
        {
            ProcessCommand(command, tokens.Skip(1).ToList());
            tokens = ParseInput(Console.ReadLine());
        }
    }

    private void ProcessCommand(string command, List<string> commandArgs)
    {
        int id = int.Parse(commandArgs[0]);
        commandArgs = commandArgs.Skip(1).ToList();

        switch (command)
        {
            case "register":
                string type = commandArgs[0];
                string brand = commandArgs[1];
                string model = commandArgs[2];
                int year = int.Parse(commandArgs[3]);
                int hp = int.Parse(commandArgs[4]);
                int acc = int.Parse(commandArgs[5]);
                int sus = int.Parse(commandArgs[6]);
                int dur = int.Parse(commandArgs[7]);
                carManager.Register(id, type, brand, model, year, hp, acc, sus, dur);
                break;
            case "check":
                OutputWriter(carManager.Check(id));
                break;
            case "open":
                carManager.Open(id, commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2],
                    int.Parse(commandArgs[3]));
                break;
            case "participate":
                carManager.Participate(id, int.Parse(commandArgs[0]));
                break;
            case "start":
                OutputWriter(carManager.Start(id));
                break;
            case "park":
                carManager.Park(id);
                break;
            case "unpark":
                carManager.Unpark(id);
                break;
            case "tune":
                carManager.Tune(id, commandArgs[0]);
                break;
            default:
                throw new InvalidOperationException("No such command exists");
        }
    }

    private void OutputWriter(string input)
    {
        Console.WriteLine(input);
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}