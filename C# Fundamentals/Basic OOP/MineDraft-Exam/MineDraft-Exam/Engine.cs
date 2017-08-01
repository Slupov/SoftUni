using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        var tokens = ParseInput(Console.ReadLine());
        string command = string.Empty;

        while (true)
        {
            command = tokens[0];
            ProcessCommand(command, tokens.Skip(1).ToList());
            if (command == "Shutdown")
            {
                break;
            }
            tokens = ParseInput(Console.ReadLine());
        }
    }

    private void ProcessCommand(string command, List<string> commandArgs)
    {
        switch (command)
        {
            case "RegisterHarvester":
                OutputWriter(this.draftManager.RegisterHarvester(commandArgs));
                break;
            case "RegisterProvider":
                OutputWriter(this.draftManager.RegisterProvider(commandArgs));
                break;
            case "Day":
                OutputWriter(draftManager.Day());
                break;
            case "Mode":
                OutputWriter(draftManager.Mode(commandArgs));
                break;
            case "Check":
                OutputWriter(this.draftManager.Check(commandArgs));
                break;
            case "Shutdown":
                OutputWriter(this.draftManager.ShutDown());
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