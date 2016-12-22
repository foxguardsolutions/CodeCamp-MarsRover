using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Adaptor
    {
        private Rover _rover;

        public Adaptor(Rover rover)
        {
            _rover = rover;
        }

        public void Execute(char command)
        {
            if (command == 'l')
                _rover.Rotate(true);
            else if (command == 'r')
                _rover.Rotate(false);
            else if (command == 'f')
                _rover.Move(true);
            else
                _rover.Move(false);
        }
    }
}
