using System;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class InitializerTests
    {
        [Test]
        [TestCase(1, 0, 'N', North)]
        public void PlaceRover_ConvertsOrientation(int x, int y, char inputDirection, CardinalDirection expectedOrientation)
        {
            var testInitializer = new Initializer();
            var rover = testInitializer.PlaceRover(x, y, inputDirection, new Grid());
            var startingOrientation = rover.GetOrientation();
            Assert.That(startingOrientation, Is.EqualTo(expectedOrientation));
        }

        [Test]
        [TestCase(1, 0)]
        public void PlaceRover_StoresLocation(int x, int y)
        {
            var testInitializer = new Initializer();
            var rover = testInitializer.PlaceRover(x, y, 'N', new Grid());
            var startingLocation = rover.GetLocation();
            var expectedLocation = new int[] { x, y };
            Assert.That(startingLocation, Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(-1, 0, "Placement point not on grid: -1, 0")]
        [TestCase(1000, 0, "Placement point not on grid: 1000, 0")]
        public void PlaceRover_ThrowsException(int x, int y, string exceptionMessage)
        {
            var testInitializer = new Initializer();
            var testGrid = new Grid();
            Assert.Throws<ArgumentException>(() => { testInitializer.PlaceRover(x, y, 'N', testGrid); }, exceptionMessage);
            Assert.That(
                () => { testInitializer.PlaceRover(x, y, 'N', testGrid); },
                Throws.ArgumentException.With.Property("Message").EqualTo(exceptionMessage));
        }
    }
}
