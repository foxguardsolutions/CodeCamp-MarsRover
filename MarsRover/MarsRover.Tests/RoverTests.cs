using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void GetLocation_WithoutMovement_Returns()
        {
            var testRover = new Rover(1, 0, CardinalDirection.North);
            Assert.That(testRover.GetLocation(), Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void GetOrientation_WithoutMovement_Returns()
        {
            var testRover = new Rover(1, 0, CardinalDirection.North);
            Assert.That(testRover.GetOrientation(), Is.EqualTo(CardinalDirection.North));
        }
    }
}