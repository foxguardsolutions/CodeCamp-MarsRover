using MarsRover.Directions;
using NUnit.Framework;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class WestDirectionTests : DirectionTests
    {
        private WestDirection _direction;

        [SetUp]
        public new void SetUp()
        {
            _direction = new WestDirection(Grid);
        }

        [Test]
        public void MoveBackward_GivenRandomPosition_MovesPositionEast()
        {
            var expected = Grid.GetNextCoordinatesEast(Position.Coordinates);

            _direction.MoveBackward(Position);
            
            Assert.That(Position.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveForward_GivenRandomPointOnGrid_MovesToWestPosition()
        {
            var expected = Grid.GetNextCoordinatesWest(Position.Coordinates);

            _direction.MoveForward(Position);
            
            Assert.That(Position.Coordinates, Is.EqualTo(expected));
        }
    }
}
