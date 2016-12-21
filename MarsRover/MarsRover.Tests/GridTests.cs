using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        [TestCase((ushort)10, (ushort)5, (ushort)10, (ushort)5)]
        [TestCase((ushort)0, (ushort)5, (ushort)1000, (ushort)5)]
        public void Size_Returns(ushort inputX, ushort inputY, ushort expectedXSize, ushort expectedYSize)
        {
            var testGrid = new Grid(inputX, inputY);
            var gridSize = testGrid.Size();
            Assert.That(gridSize, Is.EqualTo(new ushort[] { expectedXSize, expectedYSize }));
        }

        [Test]
        [TestCase(0, 0, 0, 1, true)]
        [TestCase(0, 1, 0, 1, false)]
        [TestCase(-1, 0, -1, 0, true)]
        public void HasObstacle_Returns(int obstacleX, int obstacleY, int checkX, int checkY, bool expectedResult)
        {
            var testGrid = new Grid();
            testGrid.AddObstacle(obstacleX, obstacleY);
            var hasObstacle = testGrid.IsClearOfObstacles(checkX, checkY);
            Assert.That(hasObstacle, Is.EqualTo(expectedResult));
        }
    }
}
