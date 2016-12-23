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

        [TestCaseSource(nameof(ExecuteWithoutObstaclesTestCases))]
        public void RotateRover_ChangesOrientation(
            int initialX, int initialY, char initialDirection, int finalX, int finalY, Type expectedOrientation, char[] commands)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(commands);
            var endOrientation = rover.GetOrientation();
            Assert.That(endOrientation, Is.EqualTo(expectedOrientation));
        }

        [TestCaseSource(nameof(ExecuteWithoutObstaclesTestCases))]
        public void MoveRover_OnGridWithoutObstacles_ChangesLocation(
            int initialX, int initialY, char initialDirection, int finalX, int finalY, Type expectedOrientation, char[] commands)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(commands);
            var endCoordinates = rover.GetLocation().Coordinates;
            Assert.That(endCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> ExecuteWithoutObstaclesTestCases()
        {
            yield return new TestCaseData(0, 0, 'N', 0, 0, typeof(FacingWest), new char[] { 'l' });
            yield return new TestCaseData(0, 0, 'N', 0, 0, typeof(FacingEast), new char[] { 'r' });
            yield return new TestCaseData(0, 0, 'W', 0, 0, typeof(FacingSouth), new char[] { 'l' });
            yield return new TestCaseData(0, 0, 'N', 0, 1, typeof(FacingNorth), new char[] { 'f' });
            yield return new TestCaseData(0, 1, 'N', 0, 0, typeof(FacingNorth), new char[] { 'b' });
        }

        [TestCase(new char[] { 'x' }, "Could not parse command from \"x\".")]
        [TestCase(new char[] { '!' }, "Could not parse command from \"!\".")]
        public void PlaceRover_GivenInvalidParameters_ThrowsException(char[] command, string exceptionMessage)
        {
            var rover = _initializer.PlaceRover(0, 0, 'N', _grid);
            var adaptor = new Adaptor(rover);
            Assert.Throws<ArgumentException>(() => { adaptor.Execute(command); }, exceptionMessage);
        }

        [TestCaseSource(nameof(ExecuteWithObstaclesTestCases))]
        public void MoveRover_OnGridWithObstacles_ChangesLocation(
            int initialX, int initialY, char initialDirection, ushort obstacleX, ushort obstacleY, int finalX, int finalY, Type expectedOrientation, char[] commands)
        {
            var rover = _initializer.PlaceRover(initialX, initialY, initialDirection, _grid);
            _grid.AddObstacle(obstacleX, obstacleY);
            var adaptor = new Adaptor(rover);
            adaptor.Execute(commands);
            var endCoordinates = rover.GetLocation().Coordinates;
            Assert.That(endCoordinates, Is.EqualTo(new int[] { finalX, finalY }));
        }

        private static IEnumerable<TestCaseData> ExecuteWithObstaclesTestCases()
        {
            yield return new TestCaseData(0, 0, 'E', (ushort)5, (ushort)5, 0, 2, typeof(FacingNorth), new char[] { 'l', 'f', 'f' })
                .SetName("ExecuteCommands_GivenObstaclePlacementOffRoverPath_MovesRoverToExpectedFinalCoordinates");
            yield return new TestCaseData(0, 0, 'E', (ushort)0, (ushort)2, 0, 1, typeof(FacingNorth), new char[] { 'l', 'f', 'f' })
                .SetName("ExecuteCommands_GivenObstacleOnLastPositionOfRoverPath_MovesRoverUpToObstacle");
            yield return new TestCaseData(0, 0, 'E', (ushort)0, (ushort)2, 0, 1, typeof(FacingNorth), new char[] { 'l', 'f', 'f', 'r', 'f' })
                .SetName("ExecuteCommands_GivenObstacleInMiddleOfRoverPath_MovesRoverUpToObstacle");
        }
    }
}
