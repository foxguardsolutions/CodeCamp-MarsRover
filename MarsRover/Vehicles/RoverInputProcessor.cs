using MarsRover.Vehicles.Commands;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Vehicles
{
    public class RoverInputProcessor
    {
        public Rover Rover { get; private set; }

        public RoverInputProcessor(Rover rover)
        {
            Rover = rover;
        }

        public void ExecuteCommands(IEnumerable<MovementCommand> commands)
        {
            var roverCommands = commands.Select(InterpretCommand);
            ExecuteCommands(roverCommands);
        }

        private void ExecuteCommands(IEnumerable<IRoverCommand> roverCommands)
        {
            foreach (var roverCommand in roverCommands)
                roverCommand.Execute();
        }

        private IRoverCommand InterpretCommand(MovementCommand command)
        {
            switch (command)
            {
                case MovementCommand.Backward:
                    return new MoveBackwardCommand(Rover);
                default:
                    return new MoveForwardCommand(Rover);
            }
        }
    }
}
