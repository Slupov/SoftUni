using System;
using System.Collections.Generic;
using System.Linq;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Core
{
    public class InputHandler : IInputHandler
    {
        public List<string> SplitInput(string input, string splitValue)
        {
            return input.Split(new[] {$"{splitValue}"}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}