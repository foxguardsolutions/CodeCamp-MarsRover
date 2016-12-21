using System;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class InitializerTests
    {
        private Initializer _initializer;
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _initializer = new Initializer();
            _grid = new Grid();
        }

        [Test]
        [TestCase(1, 0, "N", N)]
        [TestCase(1, 0, "n", N)]
        public void PlaceRover_ConvertsOrientation(int x, int y, string inputDirection, CardinalDirection expectedOrientation)
        {
            var rover = _initializer.PlaceRover(x, y, inputDirection, _grid);
            var startingOrientation = rover.GetOrientation();
            Assert.That(startingOrientation, Is.EqualTo(expectedOrientation));
        }

        [Test]
        [TestCase(1, 0)]
        public void PlaceRover_StoresLocation(int x, int y)
        {
            var rover = _initializer.PlaceRover(x, y, "N", _grid);
            var startingLocation = rover.GetLocation();
            var expectedLocation = new int[] { x, y };
            Assert.That(startingLocation, Is.EqualTo(expectedLocation));
        }

        [Test]
        [TestCase(-1, 0, "Placement point not on grid: -1, 0")]
        [TestCase(1000, 0, "Placement point not on grid: 1000, 0")]
        public void PlaceRover_GivenPlacementOffGrid_ThrowsException(int x, int y, string exceptionMessage)
        {
            Assert.Throws<ArgumentException>(() => { _initializer.PlaceRover(x, y, "N", _grid); }, exceptionMessage);
        }
    }
}
