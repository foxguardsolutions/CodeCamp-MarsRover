using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AdaptorTests
    {
        private Initializer _initializer;
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _initializer = new Initializer();
            _grid = new Grid();
        }

        [TestCaseSource(nameof(ExecuteTestCases))]
        public void RotateRover_ChangesOrientation(
            int initialX, int initialY, char initialDirection, char command, int finalX, int finalY, Type expectedOrientation)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(command);
            var endOrientation = rover.GetOrientation();
            Assert.That(endOrientation, Is.EqualTo(expectedOrientation));
        }

        [TestCaseSource(nameof(ExecuteTestCases))]
        public void MoveRover_ChangesLocation(
            int initialX, int initialY, char initialDirection, char command, int finalX, int finalY, Type expectedOrientation)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(command);
            var endCoordinates = rover.GetLocation().Coordinates;
            Assert.That(endCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> ExecuteTestCases()
        {
            yield return new TestCaseData(0, 0, 'N', 'l', 0, 0, typeof(FacingWest));
            yield return new TestCaseData(0, 0, 'N', 'r', 0, 0, typeof(FacingEast));
            yield return new TestCaseData(0, 0, 'W', 'l', 0, 0, typeof(FacingSouth));
            yield return new TestCaseData(0, 0, 'N', 'f', 0, 1, typeof(FacingNorth));
            yield return new TestCaseData(0, 1, 'N', 'b', 0, 0, typeof(FacingNorth));
        }
    }
}
