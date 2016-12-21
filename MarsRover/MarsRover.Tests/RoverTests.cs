using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        [TestCase(1, 0)]
        [TestCase(2, 3)]
        public void GetLocation_WithoutMovement_ReturnsInitialCoordinates(int initialX, int initialY)
        {
            var testRover = new Rover(initialX, initialY);
            var roverCoordinates = testRover.GetLocation();
            Assert.That(roverCoordinates, Is.EqualTo(new int[] { initialX, initialY }));
        }
    }
}