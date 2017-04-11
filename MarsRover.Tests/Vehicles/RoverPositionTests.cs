using MarsRover.Grids;
using MarsRover.Vehicles;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace MarsRover.Tests.Vehicles
{
    [TestFixture]
    public class RoverPositionTests
    {
        private Fixture _fixture;
        
        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void Coordinates_GivenNewRoverPosition_ReturnsCoordinatesProvided()
        {
            var coordinates = _fixture.Create<Coordinates>();
            var expected = coordinates;

            var position = new RoverPosition(coordinates);
            var actual = position.Coordinates;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
