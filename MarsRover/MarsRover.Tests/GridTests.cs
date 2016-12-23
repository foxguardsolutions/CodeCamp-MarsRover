using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class GridTests : BaseTests
    {
        private Mock<IConsoleWriter> _mockConsoleWriter;
        private Point _obstacleLocation;
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _mockConsoleWriter = new Mock<IConsoleWriter>();

            _obstacleLocation = Fixture.Create<Point>();
            _grid = new Grid(_mockConsoleWriter.Object);
        }

        [Test]
        public void MaxCoordinate_GivenPositiveSizeValues_ReturnsOneLessThanEnteredSize()
        {
            var sizeX = Fixture.Create<ushort>();
            var sizeY = Fixture.Create<ushort>();
            var expectedMaxCoordinates = new[] { (ushort)(sizeX - 1), (ushort)(sizeY - 1) };
            var grid = new Grid(sizeX, sizeY, _mockConsoleWriter.Object);

            var maxValues = new[] { grid.MaxCoordinate(0), grid.MaxCoordinate(1) };

            Assert.That(maxValues, Is.EqualTo(expectedMaxCoordinates));
        }

        [Test]
        public void MaxCoordinate_GivenSizeValuesEqualToZero_ReturnsDefaultSizeMinusOne()
        {
            var sizeX = (ushort)0;
            var sizeY = (ushort)0;
            var expectedMaxCoordinates = new ushort[] { Grid.DEFAULTSIZE - 1, Grid.DEFAULTSIZE - 1 };
            var grid = new Grid(sizeX, sizeY, _mockConsoleWriter.Object);

            var maxValues = new[] { grid.MaxCoordinate(0), grid.MaxCoordinate(1) };

            Assert.That(maxValues, Is.EqualTo(expectedMaxCoordinates));
        }

        [Test]
        public void HasObstacleAt_WithObstacleLocationSameAsInspectionLocation_ReturnsTrue()
        {
            _grid.AddObstacle(_obstacleLocation);

            var hasObstacle = _grid.HasObstacleAt(_obstacleLocation);

            Assert.That(hasObstacle, Is.True);
        }

        [Test]
        public void HasObstacleAt_WithObstacleLocationDifferentFromInspectionLocation_ReturnsFalse()
        {
            var locationClearOfObstacles = _obstacleLocation.Increment(0, Grid.DEFAULTSIZE - 1);
            _grid.AddObstacle(_obstacleLocation);

            var hasObstacle = _grid.HasObstacleAt(locationClearOfObstacles);

            Assert.That(hasObstacle, Is.False);
        }

        [Test]
        public void ValidatePoint_GivenCoordinatesOffGrid_DoesNotWriteToConsole()
        {
            var point = GivenPointOffGrid();
            var expectedMessage = $"Point not on grid: {point}";

            _grid.ValidatePoint(point);

            _mockConsoleWriter.Verify(x => x.WriteLine(expectedMessage), Times.Once());
        }

        private Point GivenPointOffGrid()
        {
            var coordinateOutsideGridLimits = Grid.DEFAULTSIZE + Fixture.Create<int>();
            Fixture.Register(() => coordinateOutsideGridLimits);
            return Fixture.Create<Point>();
        }
    }
}
