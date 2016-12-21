using System.Collections.Generic;
using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class CommandRunnerTests
    {
        private Grid _grid;
        private Rover _rover;
        private CommandRunner _commandRunner;

        [SetUp]
        protected void SetUp()
        {
            var initializer = new Initializer();
            _grid = new Grid();
            _rover = initializer.PlaceRover(0, 0, "N", _grid);
            _commandRunner = new CommandRunner();
        }

        [Test]
        [TestCase("f", new int[] { 2, 2 }, true, TestName = "TryExecuteCommand_WithNoInterferingObstacle_ReturnsTrue")]
        [TestCase("f", new int[] { 0, 1 }, false, TestName = "TryExecuteCommand_WithInterferingObstacle_ReturnsFalse")]
        public void TryExecuteCommand_Returns(string command, int[] obstacleLocation, bool expectedResult)
        {
            _grid.AddObstacle(obstacleLocation[0], obstacleLocation[1]);
            var moveWasSuccessful = _commandRunner.TryExecuteCommand(_rover, command);
            Assert.That(moveWasSuccessful, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(nameof(ExecuteCommandsTestCases))]
        public void ExecuteCommands_ChangesLocation(
            string[] commands, int[] obstacleLocation, int[] expectedLocation, CardinalDirection expectedOrientation)
        {
            _grid.AddObstacle(obstacleLocation[0], obstacleLocation[1]);
            _commandRunner.ExecuteCommands(_rover, commands);
            var endingLocation = _rover.GetLocation();
            Assert.That(endingLocation, Is.EqualTo(expectedLocation));
        }

        [TestCaseSource(nameof(ExecuteCommandsTestCases))]
        public void ExecuteCommands_ChangesOrientation(
            string[] commands, int[] obstacleLocation, int[] expectedLocation, CardinalDirection expectedOrientation)
        {
            _grid.AddObstacle(obstacleLocation[0], obstacleLocation[1]);
            _commandRunner.ExecuteCommands(_rover, commands);
            var endingOrientation = _rover.GetOrientation();
            Assert.That(endingOrientation, Is.EqualTo(expectedOrientation));
        }

        private static IEnumerable<TestCaseData> ExecuteCommandsTestCases()
        {
            yield return new TestCaseData(new string[] { "f", "r", "f" }, new int[] { 2, 2 }, new int[] { 1, 1 }, E)
                .SetName("ExecuteCommands_WithNoInterferingObstacle_ChangesPositionTo");
            yield return new TestCaseData(new string[] { "f", "r", "f" }, new int[] { 1, 1 }, new int[] { 0, 1 }, E)
                .SetName("ExecuteCommands_WithObstacleInterferingWithLastCommand_ChangesPositionTo");
            yield return new TestCaseData(new string[] { "f", "r", "f" }, new int[] { 0, 1 }, new int[] { 0, 0 }, N)
                .SetName("ExecuteCommands_WithObstacleInterferingWithFirstCommand_DoesNotChangePosition");
        }
    }
}
