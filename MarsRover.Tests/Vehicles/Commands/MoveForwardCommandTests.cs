using MarsRover.Directions;
using MarsRover.Vehicles.Commands;
using NUnit.Framework;

namespace MarsRover.Tests.Vehicles.Commands
{
    [TestFixture]
    public class MoveForwardCommandTests : TestsUsingRover
    {
        private MoveForwardCommand _command;

        [SetUp]
        public new void SetUp()
        {
            _command = new MoveForwardCommand(Rover);
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void Execute_GivenRoverFacingDirection_MovesRoverInDirectionFaced(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var expected = GetNextCoordinatesInDirection(Grid, Rover.Coordinates, cardinalDirection);

            _command.Execute();
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }
    }
}
