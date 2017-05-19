using MarsRover.Directions;
using MarsRover.Vehicles.Commands;
using NUnit.Framework;

namespace MarsRover.Tests.Vehicles.Commands
{
    [TestFixture]
    public class MoveBackwardCommandTests : TestsUsingRover
    {
        private MoveBackwardCommand _command;

        [SetUp]
        public new void SetUp()
        {
            _command = new MoveBackwardCommand(Rover);
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void Execute_GivenRoverFacingDirection_MovesRoverInOppositeDirection(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var expected = GetNextCoordinatesInOppositeDirection(Grid, Rover.Coordinates, cardinalDirection);

            _command.Execute();
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }
    }
}
