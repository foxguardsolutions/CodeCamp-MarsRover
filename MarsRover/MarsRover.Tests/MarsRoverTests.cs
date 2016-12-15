using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MarsRoverTests
    {
        [Test]
        public void NewRover_StoresLocation()
        {
            var testRover = new Rover(1, 0);
            var roverCoordinates = testRover.Location.Coordinates;
            Assert.That(roverCoordinates, Is.EqualTo(new int[] { 1, 0 }));
        }
    }
}