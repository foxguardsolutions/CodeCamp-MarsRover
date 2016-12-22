using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PositionTests
    {
        private Position _position;

        [SetUp]
        public void SetUp()
        {
            _position = new Position(1, 0, new Grid());
        }

        [Test]
        public void CoordinatesGetter_ReturnsInitialCoordinates()
        {
            var coordinates = _position.Coordinates;
            Assert.That(coordinates, Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void Clone_WithoutChangingClonedPosition_ReturnsInitialCoordinates()
        {
            var newPosition = _position.Clone();
            var newCoordinates = newPosition.Coordinates;
            Assert.That(newCoordinates, Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void Clone_WithChangeToClonedPosition_DoesNotChangeInitialCoordinates()
        {
            var newPosition = _position.Clone();
            newPosition.Coordinates[0]++;
            var oldCoordinates = _position.Coordinates;
            Assert.That(oldCoordinates, Is.EqualTo(new int[] { 1, 0 }));
        }
    }
}
