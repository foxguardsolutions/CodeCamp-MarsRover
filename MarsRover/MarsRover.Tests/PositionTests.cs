using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PositionTests : BaseTests
    {
        private int _x;
        private int _y;
        private Point _point;
        private Grid _grid;
        private Position _position;

        [SetUp]
        public void SetUp()
        {
            GenerateCoordinatesNotOnEdgeOfGrid();
            _point = new Point(_x, _y);
            _grid = Fixture.Create<Grid>();
            _position = new Position(_point, _grid);
        }

        private void GenerateCoordinatesNotOnEdgeOfGrid()
        {
            var lowEdgeCoordinate = 0;
            var highEdgeCoordinate = Grid.DEFAULTSIZE - 1;
            Fixture.Customizations.Add(
                new RandomNumericSequenceGenerator(lowEdgeCoordinate + 1, highEdgeCoordinate - 1));
            _x = Fixture.Create<int>();
            _y = Fixture.Create<int>();
        }

        [Test]
        public void GetCoordinates_ReturnsInitialCoordinates()
        {
            var coordinates = _position.GetCoordinates();
            Assert.That(coordinates, Is.EqualTo(_point));
        }

        [Test]
        public void IsClearOfObstacles_GivenNoObstacle_ReturnsTrue()
        {
            var isClear = _position.IsClearOfObstacles();
            Assert.That(isClear, Is.True);
        }

        [Test]
        public void IsClearOfObstacles_AfterPlacingObstacleAtDifferentPosition_ReturnsTrue()
        {
            var otherPosition = _position.IncrementCoordinate(0);
            _grid.AddObstacle(otherPosition.GetCoordinates());
            var isClear = _position.IsClearOfObstacles();
            Assert.That(isClear, Is.True);
        }

        [Test]
        public void IsClearOfObstacles_AfterPlacingObstacleAtSamePosition_ReturnsFalse()
        {
            _grid.AddObstacle(_position.GetCoordinates());
            var isClear = _position.IsClearOfObstacles();
            Assert.That(isClear, Is.False);
        }

        [Test]
        public void NewPosition_GivenInvalidCoordinates_WritesMessageToConsole()
        {
            var pointNotOnGrid = GivenPointOffGrid();
            var expectedMessage = $"Point not on grid: {pointNotOnGrid}";
            var mockConsoleWriter = new Mock<IConsoleWriter>();
            new Position(pointNotOnGrid, new Grid(mockConsoleWriter.Object));
            mockConsoleWriter.Verify(x => x.WriteLine(expectedMessage), Times.Once());
        }

        private Point GivenPointOffGrid()
        {
            var coordinateOutsideGridLimits = Grid.DEFAULTSIZE + Fixture.Create<int>();
            Fixture.Register(() => coordinateOutsideGridLimits);
            return Fixture.Create<Point>();
        }

        [Test]
        public void IncrementXCoordinate_GivenPositionNotOnEdgeOfGrid_ReturnsPositionWithIncrementedXCoordinate()
        {
            var coordinateIndex = 0;
            var expectedFinalPoint = new Point(_x + 1, _y);

            var newPosition = _position.IncrementCoordinate(coordinateIndex);
            var newCoordinates = newPosition.GetCoordinates();

            Assert.That(newCoordinates, Is.EqualTo(expectedFinalPoint));
        }

        [Test]
        public void IncrementYCoordinate_GivenPositionNotOnEdgeOfGrid_ReturnsPositionWithIncrementedYCoordinate()
        {
            var coordinateIndex = 1;
            var expectedFinalPoint = new Point(_x, _y + 1);

            var newPosition = _position.IncrementCoordinate(coordinateIndex);
            var newCoordinates = newPosition.GetCoordinates();

            Assert.That(newCoordinates, Is.EqualTo(expectedFinalPoint));
        }

        [Test]
        public void IncrementCoordinate_GivenPositionOnLargerCoordinateEdgeOfGrid_ReturnsPositionWithZeroCoordinateValue()
        {
            var coordinateIndex = 1;
            var initialPoint = new Point(_x, Grid.DEFAULTSIZE - 1);
            var initialPosition = new Position(initialPoint, _grid);
            var expectedFinalPoint = new Point(_x, 0);

            var newPosition = initialPosition.IncrementCoordinate(coordinateIndex);
            var newCoordinates = newPosition.GetCoordinates();

            Assert.That(newCoordinates, Is.EqualTo(expectedFinalPoint));
        }

        [Test]
        public void DecrementXCoordinate_GivenPositionNotOnEdgeOfGrid_ReturnsPositionWithDecrementedXCoordinate()
        {
            var coordinateIndex = 0;
            var expectedFinalPoint = new Point(_x - 1, _y);

            var newPosition = _position.DecrementCoordinate(coordinateIndex);
            var newCoordinates = newPosition.GetCoordinates();

            Assert.That(newCoordinates, Is.EqualTo(expectedFinalPoint));
        }

        [Test]
        public void DecrementYCoordinate_GivenPositionNotOnEdgeOfGrid_ReturnsPositionWithDecrementedYCoordinate()
        {
            var coordinateIndex = 1;
            var expectedFinalPoint = new Point(_x, _y - 1);

            var newPosition = _position.DecrementCoordinate(coordinateIndex);
            var newCoordinates = newPosition.GetCoordinates();

            Assert.That(newCoordinates, Is.EqualTo(expectedFinalPoint));
        }

        [Test]
        public void DecrementCoordinate_GivenPositionOnZeroCoordinateEdgeOfGrid_ReturnsPositionWithMaximumCoordinateValue()
        {
            var coordinateIndex = 1;
            var initialPoint = new Point(_x, 0);
            var initialPosition = new Position(initialPoint, _grid);
            var expectedFinalPoint = new Point(_x, Grid.DEFAULTSIZE - 1);

            var newPosition = initialPosition.DecrementCoordinate(coordinateIndex);
            var newCoordinates = newPosition.GetCoordinates();

            Assert.That(newCoordinates, Is.EqualTo(expectedFinalPoint));
        }
    }
}
