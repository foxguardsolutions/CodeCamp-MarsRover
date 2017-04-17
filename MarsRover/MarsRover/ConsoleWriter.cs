using System;

namespace MarsRover
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
