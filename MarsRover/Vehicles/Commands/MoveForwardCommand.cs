namespace MarsRover.Vehicles.Commands
{
    public class MoveForwardCommand : IRoverCommand
    {
        private Rover _rover;

        public MoveForwardCommand(Rover rover)
        {
            _rover = rover;
        }

        public void Execute() => _rover.MoveForward();
    }
}
