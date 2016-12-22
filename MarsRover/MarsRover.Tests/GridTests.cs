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
    }
}
