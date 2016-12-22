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
            var size = grid.Size();
            Assert.That(size, Is.EqualTo(new ushort[] { expectedX, expectedY }));
        }

        private static IEnumerable<TestCaseData> NewGridTests()
        {
            yield return new TestCaseData((ushort)10, (ushort)5, (ushort)10, (ushort)5);
            yield return new TestCaseData((ushort)0, (ushort)5, (ushort)1000, (ushort)5);
            yield return new TestCaseData((ushort)0, (ushort)0, (ushort)1000, (ushort)1000);
        }
    }
}
