using MarsRover.Grids;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests.Grids
{
    [TestFixture]
    public class BoundariesTests : Tests
    {
        private uint _height;
        private uint _width;
        
        [SetUp]
        public new void SetUp()
        {
            _height = Fixture.Create<uint>();
            _width = Fixture.Create<uint>();
        }

        [Test]
        public void LowerBound_GivenNewBoundaries_ReturnsCoordinatesOrigin()
        {
            var expected = new Coordinates(0, 0);

            var boundaries = new Boundaries(_width, _height);

            Assert.That(boundaries.LowerBound, Is.EqualTo(expected));
        }

        [Test]
        public void UpperBound_GivenNewBoundaries_ReturnsCoordinatesOfWidthAndHeightProvided()
        {
            var expected = new Coordinates(_width, _height);

            var boundaries = new Boundaries(_width, _height);

            Assert.That(boundaries.UpperBound, Is.EqualTo(expected));
        }
    }
}
