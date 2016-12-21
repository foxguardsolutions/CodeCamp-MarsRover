using System;

namespace MarsRover
{
    public class CommandParser
    {
        private const string INVALIDCOMMAND = "Could not resolve command \"{0}\".";
        private string _candidate;

        public CommandParser(string candidate)
        {
            _candidate = candidate;
        }

        public IAct CreateAction()
        {
            if (_candidate == "l")
            {
                return new Rotate(true);
            }
            else if (_candidate == "r")
            {
                return new Rotate(false);
            }
            else if (_candidate == "f")
            {
                return new Translate(true);
            }
            else if (_candidate == "b")
            {
                return new Translate(false);
            }
            else
            {
                return ReportInvalidCommand(_candidate);
            }
        }

        private IAct ReportInvalidCommand(string candidate)
        {
            var message = string.Format(INVALIDCOMMAND, candidate);
            throw new ArgumentException(message);
        }
    }
}
