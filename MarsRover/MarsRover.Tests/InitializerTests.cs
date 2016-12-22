using System;
using System.Collections.Generic;
using NUnit.Framework;

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

        [TestCaseSource(nameof(PlaceRoverTestCases))]
        public void GetLocation_GivenValidRoverPlacement_ReturnsInitialCoordinates(
            int initialX, int initialY, char initialDirection, Type expectedOrientation)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var coordinates = rover.GetLocation().Coordinates;
            Assert.That(coordinates, Is.EqualTo(new int[] { initialX, initialY }));
        }

        [TestCaseSource(nameof(PlaceRoverTestCases))]
        public void GetOrientation_GivenValidRoverPlacement_ReturnsPlacementOrientation(
            int initialX, int initialY, char initialDirection, Type expectedOrientation)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var finalOrientation = rover.GetOrientation();
            Assert.That(finalOrientation, Is.EqualTo(expectedOrientation));
        }

        private static IEnumerable<TestCaseData> PlaceRoverTestCases()
        {
            yield return new TestCaseData(0, 0, 'N', typeof(FacingNorth));
            yield return new TestCaseData(0, 0, 'E', typeof(FacingEast));
            yield return new TestCaseData(0, 0, 'S', typeof(FacingSouth));
            yield return new TestCaseData(0, 0, 'W', typeof(FacingWest));
        }

        [TestCase(0, 0, 'F', "Could not parse direction from \"F\".")]
        [TestCase(0, 0, '-', "Could not parse direction from \"-\".")]
        [TestCase(1000, 0, 'N', "Point not on grid: 1000, 0")]
        [TestCase(0, 1000, 'N', "Point not on grid: 0, 1000")]
        public void PlaceRover_GivenInvalidParameters_ThrowsException(
            int initialX, int initialY, char initialDirection, string exceptionMessage)
        {
            Assert.Throws<ArgumentException>(
                () => { _initializer.PlaceRover(initialX, initialY, initialDirection, _grid); },
                exceptionMessage);
        }
    }
}
