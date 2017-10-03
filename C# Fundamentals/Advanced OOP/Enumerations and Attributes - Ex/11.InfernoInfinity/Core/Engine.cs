using System;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Core
{
    public class Engine : IEngine
    {
        private readonly CommandDispatcher dispatcher;
        private readonly InputHandler inHandler;

        public Engine()
        {
            this.dispatcher = new CommandDispatcher();
            this.inHandler = new InputHandler();
        }

        public void Run()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = this.inHandler.SplitInput(input, ";");
                this.dispatcher.ExecuteCommand(tokens);
            }
        }
    }
}