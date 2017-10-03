using System;

namespace _05.BarracksWars___Return_of_the_Dependencies.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
