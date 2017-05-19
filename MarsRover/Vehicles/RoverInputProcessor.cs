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
            foreach (var command in roverCommands)
                if (Rover.ObstacleEncountered == null)
                    command.Execute();
        }

        private IRoverCommand InterpretCommand(MovementCommand command)
        {
            switch (command)
            {
                case MovementCommand.Backward:
                    return new MoveBackwardCommand(Rover);
                case MovementCommand.Forward:
                    return new MoveForwardCommand(Rover);
                case MovementCommand.Left:
                    return new TurnLeftCommand(Rover);
                default:
                    return new TurnRightCommand(Rover);
            }
        }
    }
}
