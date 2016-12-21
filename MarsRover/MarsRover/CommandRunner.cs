namespace MarsRover
{
    public class CommandRunner
    {
        public bool TryExecuteCommand(Rover rover, string instruction)
        {
            var commandParser = new CommandParser(instruction);
            var action = commandParser.CreateAction();
            rover.SetAction(action);
            return rover.TryMove();
        }

        public void ExecuteCommands(Rover rover, string[] commands)
        {
            foreach (string command in commands)
            {
                var executedSuccessfully = TryExecuteCommand(rover, command);
                if (!executedSuccessfully)
                {
                    break;
                }
            }
        }
    }
}
