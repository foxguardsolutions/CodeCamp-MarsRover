using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class InitializerTests : BaseTests
    {
        private Mock<IConsoleWriter> _mockConsoleWriter;
        private IConsoleWriter _consoleWriter;
        private Initializer _initializer;
        private Grid _grid;
        private int _initialX;
        private int _initialY;
        private CardinalDirection _initialDirection;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleWriter = new Mock<IConsoleWriter>();
            _consoleWriter = _mockConsoleWriter.Object;

            _initializer = new Initializer();
            _grid = new Grid(_consoleWriter);
            _initialX = Fixture.Create<int>();
            _initialY = Fixture.Create<int>();
            _initialDirection = Fixture.Create<CardinalDirection>();
        }

        [Test]
        public void GetCoordinates_AfterRoverPlacement_ReturnsInitialCoordinates()
        {
            var rover = _initializer.PlaceRover(_initialX, _initialY, _initialDirection, _grid, _consoleWriter);
            var initialLocation = rover.GetCoordinates();
            Assert.That(initialLocation, Is.EqualTo(new Point(_initialX, _initialY)));
        }

        [TestCaseSource(nameof(PlaceRoverTestCases))]
        public void GetMovementFrameOfReference_GivenValidInitialDirection_ReturnsPlacementFrameOfReference(
            CardinalDirection initialDirection, Type expectedFrameOfReference)
        {
            var rover = _initializer.PlaceRover(_initialX, _initialY, initialDirection, _grid, _consoleWriter);
            var initialFrameOfReference = rover.GetMovementFrameOfReference();
            Assert.That(initialFrameOfReference, Is.TypeOf(expectedFrameOfReference));
        }

        private static IEnumerable<TestCaseData> PlaceRoverTestCases()
        {
            yield return new TestCaseData(CardinalDirection.NORTH, typeof(MovementWhenFacingNorth));
            yield return new TestCaseData(CardinalDirection.EAST, typeof(MovementWhenFacingEast));
            yield return new TestCaseData(CardinalDirection.SOUTH, typeof(MovementWhenFacingSouth));
            yield return new TestCaseData(CardinalDirection.WEST, typeof(MovementWhenFacingWest));
        }

        [Test]
        public void PlaceRover_GivenInitialPointOffGrid_WritesMessageToConsole()
        {
            var initialX = Fixture.Create<int>();
            var initialY = Grid.DEFAULTSIZE;
            var expectedMessage = $"Point not on grid: {initialX}, {initialY}";

            _initializer.PlaceRover(initialX, initialY, _initialDirection, _grid, _consoleWriter);
            _mockConsoleWriter.Verify(x => x.WriteLine(expectedMessage), Times.Once());
        }
    }
}
