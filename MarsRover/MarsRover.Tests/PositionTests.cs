using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PositionTests
    {
        [TestCaseSource(nameof(PositionTestCases))]
        public void CoordinatesGetter_ReturnsStartingCoordinates(
            int initialX, int initialY, CardinalDirection initialOrientation, int gridSizeX, int gridSizeY)
        {
            var testPosition = new Position(initialX, initialY, initialOrientation, new Grid(gridSizeX, gridSizeY));
            Assert.That(testPosition.Coordinates, Is.EqualTo(new int[] { initialX, initialY }));
        }

        [TestCaseSource(nameof(PositionTestCases))]
        public void OrientationGetter_ReturnsStartingOrientation(
            int initialX, int initialY, CardinalDirection initialOrientation, int gridSizeX, int gridSizeY)
        {
            var testPosition = new Position(initialX, initialY, initialOrientation, new Grid(gridSizeX, gridSizeY));
            Assert.That(testPosition.Orientation, Is.EqualTo(initialOrientation));
        }

        [TestCaseSource(nameof(PositionTestCases))]
        public void GridGetter_ReturnsGridWithInitializedSize(
            int initialX, int initialY, CardinalDirection initialOrientation, int gridSizeX, int gridSizeY)
        {
            var testPosition = new Position(initialX, initialY, initialOrientation, new Grid(gridSizeX, gridSizeY));
            var gridSize = testPosition.ReferenceGrid.Size();
            Assert.That(gridSize, Is.EqualTo(new int[] { gridSizeX, gridSizeY }));
        }

        private static IEnumerable<TestCaseData> PositionTestCases()
        {
            yield return new TestCaseData(1, 0, N, 1000, 1000);
            yield return new TestCaseData(0, 1, S, 10, 100);
        }
    }
}
