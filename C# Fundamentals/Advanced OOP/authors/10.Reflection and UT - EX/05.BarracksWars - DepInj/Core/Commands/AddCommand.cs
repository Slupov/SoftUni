using _05.BarracksWars___Return_of_the_Dependencies.Attributes;
using _05.BarracksWars___Return_of_the_Dependencies.Contracts;

namespace _05.BarracksWars___Return_of_the_Dependencies.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
