using _05.BarracksWars___Return_of_the_Dependencies.Attributes;
using _05.BarracksWars___Return_of_the_Dependencies.Contracts;

namespace _05.BarracksWars___Return_of_the_Dependencies.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            this.repository.RemoveUnit(this.Data[1]);
            return $"{this.Data[1]} retired!";
        }
    }
}