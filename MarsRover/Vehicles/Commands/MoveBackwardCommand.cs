namespace MarsRover.Vehicles.Commands
{
    public class MoveBackwardCommand : IRoverCommand
    {
        private Rover _rover;

        public MoveBackwardCommand(Rover rover)
        {
            _rover = rover;
        }

        public void Execute() => _rover.MoveBackward();
    }
}
