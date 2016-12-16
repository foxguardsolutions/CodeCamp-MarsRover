using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        [TestCase(10, 5, 10, 5)]
        [TestCase(-1, 5, 1000, 5)]
        [TestCase(-1, -1, 1000, 1000)]
        [TestCase(0, 5, 1000, 5)]
        public void Size_Returns(int inputX, int inputY, int expectedXSize, int expectedYSize)
        {
            var testGrid = new Grid(inputX, inputY);
            var gridSize = testGrid.Size();
            Assert.That(gridSize, Is.EqualTo(new int[] { expectedXSize, expectedYSize }));
        }
    }
}
