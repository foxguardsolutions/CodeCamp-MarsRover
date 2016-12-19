using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class CommandRunnerTests
    {
        [Test]
        [TestCase('f', new int[] { 2, 2 }, true)]
        [TestCase('f', new int[] { 0, 1 }, false)]
        public void TryExecuteCommand_Returns(char command, int[] obstacleLocation, bool expectedResult)
        {
            var moveWasSuccessful = MakeRoverAndMoveOnceNearObstacle(command, obstacleLocation);
            Assert.That(moveWasSuccessful, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(nameof(ExecuteCommandsTestCases))]
        public void ExecuteCommands_ChangesLocation(char[] commands, int[] obstacleLocation, int[] expectedLocation, CardinalDirection expectedOrientation)
        {
            var rover = MakeRoverAndMoveMultipleTimesNearObstacle(commands, obstacleLocation);
            var endingLocation = rover.GetLocation();
            Assert.That(endingLocation, Is.EqualTo(expectedLocation));
        }

        [TestCaseSource(nameof(ExecuteCommandsTestCases))]
        public void ExecuteCommands_ChangesOrientation(char[] commands, int[] obstacleLocation, int[] expectedLocation, CardinalDirection expectedOrientation)
        {
            var rover = MakeRoverAndMoveMultipleTimesNearObstacle(commands, obstacleLocation);
            var endingOrientation = rover.GetOrientation();
            Assert.That(endingOrientation, Is.EqualTo(expectedOrientation));
        }

        private static IEnumerable<TestCaseData> ExecuteCommandsTestCases()
        {
            yield return new TestCaseData(new char[] { 'f', 'r', 'f' }, new int[] { 2, 2 }, new int[] { 1, 1 }, East);
            yield return new TestCaseData(new char[] { 'f', 'r', 'f' }, new int[] { 1, 1 }, new int[] { 0, 1 }, East);
            yield return new TestCaseData(new char[] { 'f', 'r', 'f' }, new int[] { 0, 1 }, new int[] { 0, 0 }, North);
        }

        private bool MakeRoverAndMoveOnceNearObstacle(char command, int[] obstacleLocation)
        {
            var rover = SetUpRoverGridAndObstacle(obstacleLocation);
            var commandRunner = new CommandRunner();
            return commandRunner.TryExecuteCommand(rover, command);
        }

        private Rover MakeRoverAndMoveMultipleTimesNearObstacle(char[] commands, int[] obstacleLocation)
        {
            var rover = SetUpRoverGridAndObstacle(obstacleLocation);
            var commandRunner = new CommandRunner();
            commandRunner.ExecuteCommands(rover, commands);
            return rover;
        }

        private static Rover SetUpRoverGridAndObstacle(int[] obstacleLocation)
        {
            var initializer = new Initializer();
            var grid = new Grid();
            grid.AddObstacle(obstacleLocation[0], obstacleLocation[1]);
            return initializer.PlaceRover(0, 0, 'N', grid);
        }
    }
}
