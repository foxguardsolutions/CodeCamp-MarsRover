namespace MarsRover
{
    public class CommandRunner
    {
        public bool TryExecuteCommand(Rover rover, char instruction)
        {
            var command = new Command(instruction);
            var action = command.CreateAction();
            rover.SetAction(action);
            return rover.TryMove();
        }

        public void ExecuteCommands(Rover rover, char[] commands)
        {
            foreach (char command in commands)
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
