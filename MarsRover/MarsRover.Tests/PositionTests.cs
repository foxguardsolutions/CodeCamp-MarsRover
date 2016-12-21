using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void CoordinatesGetter_ReturnsInitialCoordinates()
        {
            var testPosition = new Position(1, 0);
            var coordinates = testPosition.Coordinates;
            Assert.That(coordinates, Is.EqualTo(new int[] { 1, 0 }));
        }
    }
}
