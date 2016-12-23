using System.Collections.Generic;
using NUnit.Framework;
using Ploeh.AutoFixture;
using static MarsRover.Command;

namespace MarsRover.Tests
{
    [TestFixture]
    public class AdaptorTests : BaseTests
    {
        private Grid _grid;
        private Rover _rover;
        private Adaptor _adaptor;
        private Point _initialLocation;
        private IMovementFrameOfReference _initialFrameOfReference;

        [SetUp]
        public void SetUp()
        {
            _grid = Fixture.Create<Grid>();

            var initializer = Fixture.Create<Initializer>();
            var initialX = Fixture.Create<int>();
            var initialY = Fixture.Create<int>();
            var initialDirection = Fixture.Create<CardinalDirection>();
            var consoleWriter = Fixture.Create<IConsoleWriter>();

            _rover = initializer.PlaceRover(initialX, initialY, initialDirection, _grid, consoleWriter);
            _adaptor = new Adaptor(_rover);

            _initialLocation = _rover.GetCoordinates();
            _initialFrameOfReference = _rover.GetMovementFrameOfReference();
        }

        [TestCaseSource(nameof(RotateTestCases))]
        public void Execute_GivenRotateCommands_ChangesRoverFrameOfReference(Command[] commands)
        {
            _adaptor.Execute(commands);
            var finalFrameOfReference = _rover.GetMovementFrameOfReference();

            Assert.That(finalFrameOfReference, Is.Not.TypeOf(_initialFrameOfReference.GetType()));
        }

        private static IEnumerable<TestCaseData> RotateTestCases()
        {
            yield return new TestCaseData(new Command[] { LEFT });
            yield return new TestCaseData(new Command[] { RIGHT });
        }

        [TestCaseSource(nameof(TranslateTestCases))]
        public void Execute_GivenTranslateCommandsOnGridWithoutObstacles_ChangesRoverLocation(Command[] commands)
        {
            _adaptor.Execute(commands);
            var finalLocation = _rover.GetCoordinates();

            Assert.That(finalLocation, Is.Not.EqualTo(_initialLocation));
        }

        private static IEnumerable<TestCaseData> TranslateTestCases()
        {
            yield return new TestCaseData(new Command[] { FORWARD });
            yield return new TestCaseData(new Command[] { BACK });
        }

        [Test]
        public void ExecuteCommands_GivenObstructedRover_DoesNotMoveOrRotate()
        {
            ObstructRover();
            var commands = new Command[] { LEFT, FORWARD };

            _adaptor.Execute(commands);

            AssertRoverDidNotMoveOrRotate();
        }

        private void ObstructRover()
        {
            var obstacle = new Rover(_rover.GetCoordinates(), _rover.GetMovementFrameOfReference(), _grid, Fixture.Create<IConsoleWriter>());
            obstacle.MoveForward();
            _grid.AddObstacle(obstacle.GetCoordinates());
            _rover.MoveForward();
        }

        private void AssertRoverDidNotMoveOrRotate()
        {
            var finalLocation = _rover.GetCoordinates();
            var finalFrameOfReference = _rover.GetMovementFrameOfReference();
            Assert.That(finalLocation, Is.EqualTo(_initialLocation));
            Assert.That(finalFrameOfReference, Is.TypeOf(_initialFrameOfReference.GetType()));
        }
    }
}
