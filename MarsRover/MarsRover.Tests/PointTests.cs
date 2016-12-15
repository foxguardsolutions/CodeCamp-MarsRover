using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class PointTests
    {
        [Test]
        public void GetCoordinates_Returns()
        {
            var testPoint = new Point(1, 0);
            var coordinates = testPoint.Coordinates;
            Assert.That(coordinates, Is.EqualTo(new int[] { 1, 0 }));
        }
    }
}
