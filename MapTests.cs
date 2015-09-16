using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRover
{
    public class MapTests
    {
        private Map mars;

        [SetUp]
        public void SetUp()
        {
            List<int[]> obstacles = new List<int[]>()
            {
                new int[] { 4, 4 }, new int[] { 4, 5 }, new int[] { 4, 6 },
                new int[] { 5, 4 }, new int[] { 5, 5 }, new int[] { 5, 6 },
                new int[] { 6, 4 }, new int[] { 6, 5 }, new int[] { 6, 6 },
            };
            mars = new Map(10, 10);
            mars.Obstacles = obstacles;
        }

        [TestCase(-1, Result = 9)]
        [TestCase(10, Result = 0)]
        [TestCase(11, Result = 1)]
        [TestCase(-10, Result = 0)]
        public int ConvertXCoordinatePerformsWrapAroundWhenXIsOutOfBounds(int x)
        {
            return mars.ConvertXCoordinate(x);
        }

        [TestCase(-1, Result = 9)]
        [TestCase(10, Result = 0)]
        [TestCase(11, Result = 1)]
        [TestCase(-10, Result = 0)]
        public int ConvertYCoordinatePerformsWrapAroundWhenYIsOutOfBounds(int y)
        {
            return mars.ConvertYCoordinate(y);
        }

        [TestCase(0, 0, Result = true)]
        [TestCase(0, 1, Result = true)]
        [TestCase(0, 2, Result = true)]
        [TestCase(0, 3, Result = true)]
        [TestCase(1, 0, Result = true)]
        [TestCase(2, 0, Result = true)]
        [TestCase(3, 0, Result = true)]
        [TestCase(4, 4, Result = false)]
        [TestCase(4, 5, Result = false)]
        [TestCase(4, 6, Result = false)]
        [TestCase(5, 4, Result = false)]
        [TestCase(5, 5, Result = false)]
        [TestCase(5, 6, Result = false)]
        [TestCase(6, 4, Result = false)]
        [TestCase(6, 5, Result = false)]
        [TestCase(6, 6, Result = false)]
        public bool CanMoveToReturnsTrueForAllCoordinatesNotInObstaclesList(int x, int y)
        {
            return mars.CanMoveTo(x, y);
        }
    }
}
