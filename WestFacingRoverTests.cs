using System;
using NUnit.Framework;

namespace MarsRover
{
    [TestFixture]
    public class WestFacingRoverTests
    {
        [TestCase(typeof(WestFacingRover), 0, 0, 'F', Result = new int[] { -1, 0 })]
        [TestCase(typeof(WestFacingRover), 1, 1, 'F', Result = new int[] { 0, 1 })]
        [TestCase(typeof(WestFacingRover), 100, 100, 'F', Result = new int[] { 99, 100 })]
        [TestCase(typeof(WestFacingRover), 0, 0, 'B', Result = new int[] { 1, 0 })]
        [TestCase(typeof(WestFacingRover), 1, 1, 'B', Result = new int[] { 2, 1 })]
        [TestCase(typeof(WestFacingRover), 100, 100, 'B', Result = new int[] { 101, 100 })]
        public int[] WestFacingRoverMoveMethodSubtractsAndAddsToCoordinatesCorrectly(Type roverType, int startX, int startY, char movement)
        {
            IRover rover = (IRover)Activator.CreateInstance(roverType, startX, startY);
            rover = rover.Move(movement);
            return new int[] { rover.X, rover.Y };
        }

        [TestCase(typeof(WestFacingRover), 'L', typeof(SouthFacingRover))]
        [TestCase(typeof(WestFacingRover), 'R', typeof(NorthFacingRover))]
        public void WestFacingRoverReturnsCorrectDirectionalRoverAfterTurning(Type startType, char direction, Type endType)
        {
            IRover rover = (IRover)Activator.CreateInstance(startType, 0, 0);
            var rover2 = rover.Move(direction);
            Assert.IsInstanceOf(endType, rover2);
        }
    }
}
