using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverTests : BaseTests
    {
        private Mock<IConsoleWriter> _mockConsoleWriter;
        private IConsoleWriter _consoleWriter;
        private Grid _grid;
        private Point _startingPoint;
        private Rover _rover;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleWriter = new Mock<IConsoleWriter>();
            _consoleWriter = _mockConsoleWriter.Object;
            _grid = Fixture.Create<Grid>();
            _startingPoint = Fixture.Create<Point>();
            var initialFrameOfReference = Fixture.Create<IMovementFrameOfReference>();
            _rover = new Rover(_startingPoint, initialFrameOfReference, _grid, _consoleWriter);
        }

        [TestCaseSource(nameof(NoRotationTestCases))]
        public void GetMovementFrameOfReference_WithoutRotation_ReturnsInitialFrameOfReference(IMovementFrameOfReference initialFrameOfReference)
        {
            _rover.SetFrameOfReference(initialFrameOfReference);
            var expectedFrameOfReference = initialFrameOfReference.GetType();

            var finalFrameOfReferenceType = _rover.GetMovementFrameOfReference().GetType();

            Assert.That(finalFrameOfReferenceType, Is.EqualTo(expectedFrameOfReference));
        }

        private static IEnumerable<TestCaseData> NoRotationTestCases()
        {
            yield return new TestCaseData(new MovementWhenFacingNorth());
            yield return new TestCaseData(new MovementWhenFacingEast());
            yield return new TestCaseData(new MovementWhenFacingSouth());
            yield return new TestCaseData(new MovementWhenFacingWest());
        }

        [Test]
        public void GetCoordinates_WithoutMovement_ReturnsInitialCoordinates()
        {
            var roverCoordinates = _rover.GetCoordinates();
            Assert.That(roverCoordinates, Is.EqualTo(_startingPoint));
        }

        [Test]
        public void MoveForward_WithoutObstacle_DisplaysCorrectMovementBehavior()
        {
            _rover.MoveForward();
            AssertRoverDisplaysCorrectMovementBehavior();
        }

        [Test]
        public void MoveBackward_WithoutObstacle_DisplaysCorrectMovementBehavior()
        {
            _rover.MoveBackward();
            AssertRoverDisplaysCorrectMovementBehavior();
        }

        private void AssertRoverDisplaysCorrectMovementBehavior()
        {
            AssertMoved();
            AssertObstructionStatusIs(false);
        }

        [Test]
        public void Move_WithObstacleInNextPosition_DisplaysObstacleEncounterBehavior()
        {
            var obstacleCoordinates = GetNextRoverPosition();

            _grid.AddObstacle(obstacleCoordinates);
            _rover.MoveForward();

            AssertRoverDisplaysObstacleEncounterBehavior(obstacleCoordinates);
        }

        private Point GetNextRoverPosition()
        {
            var fakeRover = new Rover(_rover.GetCoordinates(), _rover.GetMovementFrameOfReference(), _grid, _consoleWriter);
            fakeRover.MoveForward();
            return fakeRover.GetCoordinates();
        }

        private void AssertRoverDisplaysObstacleEncounterBehavior(Point obstacleCoordinates)
        {
            AssertDidntMove();
            AssertObstructionStatusIs(true);
            AssertCreatedObstacleReport(obstacleCoordinates);
        }

        private void AssertMoved()
        {
            var roverCoordinates = _rover.GetCoordinates();
            Assert.That(roverCoordinates, Is.Not.EqualTo(_startingPoint));
        }

        private void AssertDidntMove()
        {
            var roverCoordinates = _rover.GetCoordinates();
            Assert.That(roverCoordinates, Is.EqualTo(_startingPoint));
        }

        private void AssertObstructionStatusIs(bool expectedObstructionStatus)
        {
            var isObstructed = _rover.IsObstructed();
            Assert.That(isObstructed, Is.EqualTo(expectedObstructionStatus));
        }

        private void AssertCreatedObstacleReport(Point obstacleCoordinates)
        {
            var expectedMessage = $"Obstacle encountered at position ({obstacleCoordinates}). Movement terminated.";
            _mockConsoleWriter.Verify(x => x.WriteLine(expectedMessage), Times.Once());
        }
    }
}