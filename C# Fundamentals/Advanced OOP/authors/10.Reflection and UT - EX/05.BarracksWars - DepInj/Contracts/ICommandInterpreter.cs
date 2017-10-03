namespace _05.BarracksWars___Return_of_the_Dependencies.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
