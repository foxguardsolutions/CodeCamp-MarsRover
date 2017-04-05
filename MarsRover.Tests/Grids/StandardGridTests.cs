using MarsRover.Grids;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests.Grids
{
    [TestFixture]
    public class StandardGridTests : Tests
    {
        private Coordinates _coordinates;
        private StandardGrid _grid;

        [SetUp]
        public new void SetUp()
        {
            _coordinates = Fixture.Create<Coordinates>();
            _grid = new StandardGrid();
        }

        [Test]
        public void GetNextCoordinatesEast_GivenCoordinates_ReturnsXIncreasedBy1()
        {
            var expected = new Coordinates(_coordinates.X + 1, _coordinates.Y);

            var actual = _grid.GetNextCoordinatesEast(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesNorth_GivenCoordinates_ReturnsYIncreasedBy1()
        {
            var expected = new Coordinates(_coordinates.X, _coordinates.Y + 1);

            var actual = _grid.GetNextCoordinatesNorth(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesSouth_GivenCoordinates_ReturnsYDecreasedBy1()
        {
            var expected = new Coordinates(_coordinates.X, _coordinates.Y - 1);

            var actual = _grid.GetNextCoordinatesSouth(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetNextCoordinatesWest_GivenCoordinates_ReturnsXDecreasedBy1()
        {
            var expected = new Coordinates(_coordinates.X - 1, _coordinates.Y);

            var actual = _grid.GetNextCoordinatesWest(_coordinates);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
