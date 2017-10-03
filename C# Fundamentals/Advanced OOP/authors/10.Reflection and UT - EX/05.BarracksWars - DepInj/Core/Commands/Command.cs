using _05.BarracksWars___Return_of_the_Dependencies.Contracts;

namespace _05.BarracksWars___Return_of_the_Dependencies.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
       
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public abstract string Execute();
    }
}