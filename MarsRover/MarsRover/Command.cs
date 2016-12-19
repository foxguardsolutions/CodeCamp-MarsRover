using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Command
    {
        private Type _strategyType;
        private bool _hasPositiveDirectionOfMovement;
        private static Dictionary<char, Type> _validCommands = new Dictionary<char, Type>()
        {
            { 'l', typeof(Rotate) },
            { 'r', typeof(Rotate) },
            { 'f', typeof(Translate) },
            { 'b', typeof(Translate) },
        };
        private static char[] _commandsWithPositiveDirectionOfMovement = new char[] { 'l', 'f' };

        public Command(char candidate)
        {
            _strategyType = _validCommands[candidate];
            _hasPositiveDirectionOfMovement = HasPositiveSign(candidate);
        }

        private bool HasPositiveSign(char value)
        {
            return _commandsWithPositiveDirectionOfMovement.Contains(value);
        }

        public IAct CreateAction()
        {
            return (IAct)Activator.CreateInstance(_strategyType, new object[] { _hasPositiveDirectionOfMovement });
        }
    }
}
