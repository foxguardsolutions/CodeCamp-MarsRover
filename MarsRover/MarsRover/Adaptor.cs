using System;

namespace MarsRover
{
    public class Adaptor
    {
        private const string INVALIDCOMMAND = "Could not parse command from \"{0}\".";
        private Rover _rover;

        public Adaptor(Rover rover)
        {
            _rover = rover;
        }

        public void Execute(char[] commands)
        {
            foreach (char command in commands)
            {
                Execute(command);
            }
        }

        public void Execute(char command)
        {
            if (command == 'l')
                _rover.Rotate(true);
            else if (command == 'r')
                _rover.Rotate(false);
            else if (command == 'f')
                _rover.Move(true);
            else if (command == 'b')
                _rover.Move(false);
            else
                ReportInvalidCommand(command);
        }

        private void ReportInvalidCommand(char command)
        {
            var message = string.Format(INVALIDCOMMAND, command);
            throw new ArgumentException(message);
        }
    }
}
