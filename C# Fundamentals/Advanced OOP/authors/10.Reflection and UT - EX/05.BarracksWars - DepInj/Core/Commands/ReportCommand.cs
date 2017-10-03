using _05.BarracksWars___Return_of_the_Dependencies.Attributes;
using _05.BarracksWars___Return_of_the_Dependencies.Contracts;

namespace _05.BarracksWars___Return_of_the_Dependencies.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
