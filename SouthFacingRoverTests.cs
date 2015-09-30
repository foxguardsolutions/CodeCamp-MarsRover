using System;
using NUnit.Framework;

namespace MarsRover
{
    [TestFixture]
    public class SouthFacingRoverTests
    {
        [TestCase(typeof(SouthFacingRover), 0, 0, 'F', Result = new int[] { 0, 1 })]
        [TestCase(typeof(SouthFacingRover), 1, 1, 'F', Result = new int[] { 1, 2 })]
        [TestCase(typeof(SouthFacingRover), 100, 100, 'F', Result = new int[] { 100, 101 })]
        [TestCase(typeof(SouthFacingRover), 0, 0, 'B', Result = new int[] { 0, -1 })]
        [TestCase(typeof(SouthFacingRover), 1, 1, 'B', Result = new int[] { 1, 0 })]
        [TestCase(typeof(SouthFacingRover), 100, 100, 'B', Result = new int[] { 100, 99 })]
        public int[] NorthFacingRoverMoveMethodSubtractsAndAddsToCoordinatesCorrectly(Type roverType, int startX, int startY, char movement)
        {
            IRover rover = (IRover)Activator.CreateInstance(roverType, startX, startY);
            rover = rover.Move(movement);
            return new int[] { rover.X, rover.Y };
        }

        [TestCase(typeof(SouthFacingRover), 'L', typeof(EastFacingRover))]
        [TestCase(typeof(SouthFacingRover), 'R', typeof(WestFacingRover))]
        public void WestFacingRoverReturnsCorrectDirectionalRoverAfterTurning(Type startType, char direction, Type endType)
        {
            IRover rover = (IRover)Activator.CreateInstance(startType, 0, 0);
            var rover2 = rover.Move(direction);
            Assert.IsInstanceOf(endType, rover2);
        }
    }
}
