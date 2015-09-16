using System;
using NUnit.Framework;

namespace MarsRover
{
    [TestFixture]
    public class NorthFacingRoverTests
    {
        [TestCase(typeof(NorthFacingRover), 0, 0, 'F', Result = new int[] { 0, -1 })]
        [TestCase(typeof(NorthFacingRover), 1, 1, 'F', Result = new int[] { 1, 0 })]
        [TestCase(typeof(NorthFacingRover), 100, 100, 'F', Result = new int[] { 100, 99 })]
        [TestCase(typeof(NorthFacingRover), 0, 0, 'B', Result = new int[] { 0, 1 })]
        [TestCase(typeof(NorthFacingRover), 1, 1, 'B', Result = new int[] { 1, 2 })]
        [TestCase(typeof(NorthFacingRover), 100, 100, 'B', Result = new int[] { 100, 101 })]
        public int[] NorthFacingRoverMoveMethodSubtractsAndAddsToCoordinatesCorrectly(Type roverType, int startX, int startY, char movement)
        {
            IRover rover = (IRover)Activator.CreateInstance(roverType, startX, startY);
            rover = rover.Move(movement);
            return new int[] { rover.X, rover.Y };
        }

        [TestCase(typeof(NorthFacingRover), 'L', typeof(WestFacingRover))]
        [TestCase(typeof(NorthFacingRover), 'R', typeof(EastFacingRover))]
        public void WestFacingRoverReturnsCorrectDirectionalRoverAfterTurning(Type startType, char direction, Type endType)
        {
            IRover rover = (IRover)Activator.CreateInstance(startType, 0, 0);
            var rover2 = rover.Move(direction);
            Assert.IsInstanceOf(endType, rover2);
        }
    }
}
