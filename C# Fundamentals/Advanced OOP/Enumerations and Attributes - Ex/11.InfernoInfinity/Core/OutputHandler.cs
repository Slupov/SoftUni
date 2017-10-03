using System;
using InfernoInfinity.Interfaces;

namespace InfernoInfinity.Core
{
    public class OutputHandler : IOutputHandler
    {
        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}