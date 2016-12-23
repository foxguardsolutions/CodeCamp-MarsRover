using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PointTests : BaseTests
    {
        private int _maxCoordinate;
        private int _x;
        private int _y;
        private Point _point;

        [SetUp]
        public void Setup()
        {
            Fixture.Customizations.Add(new RandomNumericSequenceGenerator(3, Grid.DEFAULTSIZE - 1));
            _maxCoordinate = Fixture.Create<int>();

            Fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, _maxCoordinate - 1));
            _x = Fixture.Create<int>();
            _y = Fixture.Create<int>();

            _point = new Point(_x, _y);
        }

        [Test]
        public void ToString_Returns()
        {
            var expectedRepresentation = $"{_x}, {_y}";
            var stringRepresentation = _point.ToString();
            Assert.That(stringRepresentation, Is.EqualTo(expectedRepresentation));
        }

        [Test]
        public void IncrementXCoordinate_GivenCoordinateLessThanMaximum_ReturnsPointWithIncrementedXValue()
        {
            var coordinateIndex = 0;
            var expectedFinalPoint = new Point(_x + 1, _y);
            AssertIncrementsCorrectly(_point, coordinateIndex, expectedFinalPoint);
        }

        [Test]
        public void IncrementYCoordinate_GivenCoordinateLessThanMaximum_ReturnsPointWithIncrementedYValue()
        {
            var coordinateIndex = 1;
            var expectedFinalPoint = new Point(_x, _y + 1);
            AssertIncrementsCorrectly(_point, coordinateIndex, expectedFinalPoint);
        }

        [Test]
        public void IncrementCoordinate_GivenCoordinateEqualToMaximum_ReturnsPointWithCoordinateValueAtZero()
        {
            var coordinateIndex = 0;
            var initialPoint = new Point(_maxCoordinate, _y);
            var expectedFinalPoint = new Point(0, _y);
            AssertIncrementsCorrectly(initialPoint, coordinateIndex, expectedFinalPoint);
        }

        public void AssertIncrementsCorrectly(Point initialPoint, int index, Point expectedFinalPoint)
        {
            var newPoint = initialPoint.Increment(index, _maxCoordinate);
            Assert.That(newPoint, Is.EqualTo(expectedFinalPoint));
        }

        [Test]
        public void DecrementXCoordinate_GivenCoordinateGreaterThanZero_ReturnsPointWithDecrementedXValue()
        {
            var coordinateIndex = 0;
            var expectedFinalPoint = new Point(_x - 1, _y);
            AssertDecrementsCorrectly(_point, coordinateIndex, expectedFinalPoint);
        }

        [Test]
        public void DecrementYCoordinate_GivenCoordinateGreaterThanZero_ReturnsPointWithDecrementedYValue()
        {
            var coordinateIndex = 1;
            var expectedFinalPoint = new Point(_x, _y - 1);
            AssertDecrementsCorrectly(_point, coordinateIndex, expectedFinalPoint);
        }

        [Test]
        public void DecrementCoordinate_GivenCoordinateEqualToZero_ReturnsPointWithCoordinateValueAtMaximum()
        {
            var coordinateIndex = 0;
            var initialPoint = new Point(0, _y);
            var expectedFinalPoint = new Point(_maxCoordinate, _y);
            AssertDecrementsCorrectly(initialPoint, coordinateIndex, expectedFinalPoint);
        }

        public void AssertDecrementsCorrectly(
            Point initialPoint, int index, Point expectedFinalPoint)
        {
            var newPoint = initialPoint.Decrement(index, _maxCoordinate);
            Assert.That(newPoint, Is.EqualTo(expectedFinalPoint));
        }
    }
}
