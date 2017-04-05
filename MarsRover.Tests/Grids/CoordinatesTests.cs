using Ploeh.AutoFixture;
using MarsRover.Grids;
using NUnit.Framework;

namespace MarsRover.Tests.Grids
{
    [TestFixture]
    public class CoordinatesTests : Tests
    {
        private Coordinates _coordinates;
        
        [SetUp]
        public new void SetUp()
        {
            _coordinates = Fixture.Create<Coordinates>();
        }

        [Test]
        public void ToString_GivenCoordinates_ReturnsStringDetailingXandYCoordinates()
        {
            var expected = $"({_coordinates.X}, {_coordinates.Y})";

            var actual = _coordinates.ToString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
