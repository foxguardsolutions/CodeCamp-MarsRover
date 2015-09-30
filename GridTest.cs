using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    using NUnit.Framework;

    [TestFixture]
    public class GridTest
    {
        [TestCase(0, 0, 0, 0)]
        [TestCase(9, 9, 9, 9)]
        [TestCase(3, 7, 3, 7)]
        [TestCase(-1, 0, 9, 0)]
        [TestCase(0, -1, 0, 9)]
        [TestCase(10, 0, 0, 0)]
        [TestCase(0, 10, 0, 0)]
        public void TestGridCellAt(int x, int y, int expectedX, int expectedY)
        {
            Grid grid = new Grid(10, 10);

            GridCell gridCell = grid.GridCellAt(x, y);

            Assert.AreEqual(expectedX, gridCell.X);
            Assert.AreEqual(expectedY, gridCell.Y);
        }
    }
}
