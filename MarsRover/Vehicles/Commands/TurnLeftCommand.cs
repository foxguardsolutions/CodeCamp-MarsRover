namespace MarsRover.Vehicles.Commands
{
    public class TurnLeftCommand : IRoverCommand
    {
        private Rover _rover;

        public TurnLeftCommand(Rover rover)
        {
            _rover = rover;
        }

        public void Execute() => _rover.TurnLeft();
    }
}
