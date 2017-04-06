using MarsRover.Directions;
using MarsRover.Grids;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests.Vehicles
{
    [TestFixture]
    public class RoverTests : TestsUsingRover
    {
        [TestCaseSource(nameof(CardinalDirections))]
        public void MoveBackward_GivenRoverFacingDirection_MovesRoverInOppositeDirectionOnGrid(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var expected = GetNextCoordinatesInOppositeDirection(Grid, Rover.Coordinates, cardinalDirection);

            Rover.MoveBackward();
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(CardinalDirections))]
        public void MoveForward_GivenRoverFacingDirection_MovesRoverInDirectionFacedOnGrid(CardinalDirection cardinalDirection)
        {
            GivenRoverFacingDirection(cardinalDirection);
            var expected = GetNextCoordinatesInDirection(Grid, Rover.Coordinates, cardinalDirection);

            Rover.MoveForward();
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveTo_GivenCoordinates_ChangesMoverCoordinatesToNewCoordinates()
        {
            var expected = Fixture.Create<Coordinates>();
            
            Rover.MoveTo(expected);
            
            Assert.That(Rover.Coordinates, Is.EqualTo(expected));
        }
    }
}
