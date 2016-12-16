using NUnit.Framework;
using static MarsRover.CardinalDirection;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void CoordinatesGetter_Returns()
        {
            var testPosition = new Position(1, 0, North, new Grid());
            Assert.That(testPosition.Coordinates, Is.EqualTo(new int[] { 1, 0 }));
        }

        [Test]
        public void OrientationGetter_Returns()
        {
            var testPosition = new Position(1, 0, North, new Grid());
            Assert.That(testPosition.Orientation, Is.EqualTo(North));
        }

        [Test]
        public void GridGetter_Returns()
        {
            var testPosition = new Position(1, 0, North, new Grid());
            var gridMax = testPosition.ReferenceGrid.Size();
            Assert.That(gridMax, Is.EqualTo(new int[] { 1000, 1000 }));
        }
    }
}
