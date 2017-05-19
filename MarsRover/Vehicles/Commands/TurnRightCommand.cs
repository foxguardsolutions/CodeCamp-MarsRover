namespace MarsRover.Vehicles.Commands
{
    public class TurnRightCommand : IRoverCommand
    {
        private Rover _rover;

        public TurnRightCommand(Rover rover)
        {
            _rover = rover;
        }

        public void Execute() => _rover.TurnRight();
    }
}
