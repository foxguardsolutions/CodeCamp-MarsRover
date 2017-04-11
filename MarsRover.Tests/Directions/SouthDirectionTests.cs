using MarsRover.Directions;
using NUnit.Framework;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class SouthDirectionTests : DirectionTests
    {
        private SouthDirection _direction;

        [SetUp]
        public new void SetUp()
        {
            _direction = new SouthDirection(Grid);
        }

        [Test]
        public void MoveBackward_GivenRandomPointOnGrid_MovesToNorthPosition()
        {
            var expected = Grid.GetNextCoordinatesNorth(Position.Coordinates);

            _direction.MoveBackward(Position);
            
            Assert.That(Position.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveForward_GivenRandomPointOnGrid_MovesToSouthPosition()
        {
            var expected = Grid.GetNextCoordinatesSouth(Position.Coordinates);

            _direction.MoveForward(Position);
            
            Assert.That(Position.Coordinates, Is.EqualTo(expected));
        }
    }
}
