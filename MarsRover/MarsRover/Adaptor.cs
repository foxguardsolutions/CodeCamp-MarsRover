using static MarsRover.Command;

namespace MarsRover
{
    public class Adaptor
    {
        private Rover _rover;

        public Adaptor(Rover rover)
        {
            _rover = rover;
        }

        public void Execute(Command[] commands)
        {
            foreach (var command in commands)
            {
                if (!_rover.IsObstructed())
                {
                    Execute(command);
                }
            }
        }

        private void Execute(Command command)
        {
            if (command == LEFT)
                _rover.RotateClockwise();
            else if (command == RIGHT)
                _rover.RotateCounterclockwise();
            else if (command == FORWARD)
                _rover.MoveForward();
            else if (command == BACK)
                _rover.MoveBackward();
        }
    }
}
