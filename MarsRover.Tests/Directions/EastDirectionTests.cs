using MarsRover.Directions;
using NUnit.Framework;

namespace MarsRover.Tests.Directions
{
    [TestFixture]
    public class EastDirectionTests : DirectionTests
    {
        private EastDirection _direction;

        [SetUp]
        public new void SetUp()
        {
            _direction = new EastDirection(Grid);
        }

        [Test]
        public void MoveBackward_GivenRandomPointOnGrid_MovesToWestPosition()
        {
            var expected = Grid.GetNextCoordinatesWest(Position.Coordinates);

            _direction.MoveBackward(Position);

            Assert.That(Position.Coordinates, Is.EqualTo(expected));
        }

        [Test]
        public void MoveForward_GivenRandomPointOnGrid_MovesToEastPosition()
        {
            var expected = Grid.GetNextCoordinatesEast(Position.Coordinates);

            _direction.MoveForward(Position);

            Assert.That(Position.Coordinates, Is.EqualTo(expected));
        }
    }
}
