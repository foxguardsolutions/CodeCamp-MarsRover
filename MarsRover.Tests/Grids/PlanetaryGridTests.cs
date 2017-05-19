using MarsRover.Grids;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests.Grids
{
    [TestFixture]
    public class PlanetaryGridTests : Tests
    {
        private uint _x;
        private uint _xRangeLength;
        private uint _y;
        private uint _yRangeLength;
        private Coordinates _coordinates;
        private PlanetaryGrid _grid;

        [SetUp]
        public new void SetUp()
        {
            _grid = Fixture.Create<PlanetaryGrid>();
            _x = Fixture.CreateUIntInRange(_grid.Boundaries.LowerBound.X, _grid.Boundaries.UpperBound.X);
            _y = Fixture.CreateUIntInRange(_grid.Boundaries.LowerBound.Y, _grid.Boundaries.UpperBound.Y);
            _xRangeLength = _grid.Boundaries.UpperBound.X - _grid.Boundaries.LowerBound.X + 1;
            _yRangeLength = _grid.Boundaries.UpperBound.Y - _grid.Boundaries.LowerBound.Y + 1;
            _coordinates = new Coordinates(_x, _y);
        }

        [Test]
        public void GetNextCoordinatesEast_GivenRandomCoordinates_ReturnsCoorindatesOfNextLocationToTheEast()
        {
            var nextX = _coordinates.X == _grid.Boundaries.UpperBound.X ? _grid.Boundaries.LowerBound.X : _coordinates.X + 1;
            var expected = new Coordinates(nextX, _coordinates.Y);
            
            var actual = _grid.GetNextCoordinatesEast(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesEast_GivenCoordinatesAtEasternEdge_ReturnsCoordinatesAtWesternEdge()
        {
            var coordinates = new Coordinates(_grid.Boundaries.UpperBound.X, _y);
            var expected = new Coordinates(_grid.Boundaries.LowerBound.X, coordinates.Y);
            
            var actual = _grid.GetNextCoordinatesEast(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesEast_GivenCoordinatesOutOfBounds_ReturnsCoordinatesEastOfCoordinatesInBounds()
        {
            var coordinates = new Coordinates(_x + _xRangeLength, _y + _yRangeLength);
            var nextX = _x == _grid.Boundaries.UpperBound.X ? _grid.Boundaries.LowerBound.X : _x + 1;
            var expected = new Coordinates(nextX, _y);

            var actual = _grid.GetNextCoordinatesEast(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesNorth_GivenRandomCoordinates_ReturnsCoordinatesOfNextLocationToTheNorth()
        {
            var nextY = _coordinates.Y == _grid.Boundaries.UpperBound.Y ? _grid.Boundaries.LowerBound.Y : _coordinates.Y + 1;
            var expected = new Coordinates(_coordinates.X, nextY);
            
            var actual = _grid.GetNextCoordinatesNorth(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesNorth_GivenCoordinatesAtNorthernEdge_ReturnsCoordinatesAtSouthernEdge()
        {
            var coordinates = new Coordinates(_x, _grid.Boundaries.UpperBound.Y);
            var expected = new Coordinates(coordinates.X, _grid.Boundaries.LowerBound.Y);
            
            var actual = _grid.GetNextCoordinatesNorth(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesNorth_GivenCoordinatesOutOfBounds_ReturnsCoordinatesNorthOfCoordinatesInBounds()
        {
            var coordinates = new Coordinates(_x + _xRangeLength, _y + _yRangeLength);
            var nextY = _y == _grid.Boundaries.UpperBound.Y ? _grid.Boundaries.LowerBound.Y : _y + 1;
            var expected = new Coordinates(_x, nextY);

            var actual = _grid.GetNextCoordinatesNorth(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesSouth_GivenRandomCoordinates_ReturnsCoordinatesOfNextLocationToTheSouth()
        {
            var nextY = _coordinates.Y == _grid.Boundaries.LowerBound.Y ? _grid.Boundaries.UpperBound.Y : _coordinates.Y - 1;
            var expected = new Coordinates(_coordinates.X, nextY);

            var actual = _grid.GetNextCoordinatesSouth(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesSouth_GivenCoordinatesAtSouthernEdge_ReturnsCoordinatesAtNorthernEdge()
        {
            var coordinates = new Coordinates(_x, _grid.Boundaries.LowerBound.Y);
            var expected = new Coordinates(coordinates.X, _grid.Boundaries.UpperBound.Y);

            var actual = _grid.GetNextCoordinatesSouth(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesSouth_GivenCoordinatesOutOfBounds_ReturnsCoordinatesSouthOfCoordinatesInBounds()
        {
            var coordinates = new Coordinates(_x + _xRangeLength, _y + _yRangeLength);
            var nextY = _y == _grid.Boundaries.LowerBound.Y ? _grid.Boundaries.UpperBound.Y : _y - 1;
            var expected = new Coordinates(_x, nextY);

            var actual = _grid.GetNextCoordinatesSouth(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesWest_GivenRandomCoordinates_ReturnsCoordinatesOfNextLocationToTheWest()
        {
            var nextX = _coordinates.X == _grid.Boundaries.LowerBound.X ? _grid.Boundaries.UpperBound.X : _coordinates.X - 1;
            var expected = new Coordinates(nextX, _coordinates.Y);

            var actual = _grid.GetNextCoordinatesWest(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesWest_GivenCoordinatesAtWesternEdge_ReturnsCoordinatesAtEasternEdge()
        {
            var coordinates = new Coordinates(_grid.Boundaries.LowerBound.X, _y);
            var expected = new Coordinates(_grid.Boundaries.UpperBound.X, coordinates.Y);

            var actual = _grid.GetNextCoordinatesWest(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesWest_GivenCoordinatesOutOfBounds_ReturnsCoordinatesWestOfCoordinatesInBounds()
        {
            var coordinates = new Coordinates(_x + _xRangeLength, _y + _yRangeLength);
            var nextX = _x == _grid.Boundaries.LowerBound.X ? _grid.Boundaries.UpperBound.X : _x - 1;
            var expected = new Coordinates(nextX, _y);

            var actual = _grid.GetNextCoordinatesWest(coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
