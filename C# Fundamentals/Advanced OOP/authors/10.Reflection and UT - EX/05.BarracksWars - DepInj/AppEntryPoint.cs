using _05.BarracksWars___Return_of_the_Dependencies.Contracts;
using _05.BarracksWars___Return_of_the_Dependencies.Core;
using _05.BarracksWars___Return_of_the_Dependencies.Core.Factories;
using _05.BarracksWars___Return_of_the_Dependencies.Data;

namespace _05.BarracksWars___Return_of_the_Dependencies
{
    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
