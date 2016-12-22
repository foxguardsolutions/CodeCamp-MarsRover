using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class GridTests
    {
        [TestCaseSource(nameof(NewGridTests))]
        public void Size_ReturnsInitialValues(ushort inputX, ushort inputY, ushort expectedX, ushort expectedY)
        {
            var grid = new Grid(inputX, inputY);
            var size = new ushort[] { grid.MaxCoordinate(0), grid.MaxCoordinate(1) };
            Assert.That(size, Is.EqualTo(new ushort[] { expectedX, expectedY }));
        }

        private static IEnumerable<TestCaseData> NewGridTests()
        {
            yield return new TestCaseData((ushort)10, (ushort)5, (ushort)9, (ushort)4);
            yield return new TestCaseData((ushort)0, (ushort)5, (ushort)999, (ushort)4);
            yield return new TestCaseData((ushort)0, (ushort)0, (ushort)999, (ushort)999);
        }

        [TestCase((ushort)1, (ushort)2, 1, 2, true)]
        [TestCase((ushort)1, (ushort)2, 1, 1, false)]
        [TestCase((ushort)1000, (ushort)2, 1000, 2, false)]
        public void HasObstacle_GivenPointWithoutObstacle_ReturnsFalse(
            ushort addX, ushort addY, int checkX, int checkY, bool expectedValue)
        {
            var grid = new Grid();
            grid.AddObstacle(addX, addY);
            Assert.That(grid.HasObstacle(checkX, checkY), Is.EqualTo(expectedValue));
        }
    }
}
