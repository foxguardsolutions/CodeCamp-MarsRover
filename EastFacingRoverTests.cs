using System;
using NUnit.Framework;

namespace MarsRover
{
    [TestFixture]
    public class EastFacingRoverTests
    {
        [TestCase(typeof(EastFacingRover), 0, 0, 'F', Result = new int[] { 1, 0 })]
        [TestCase(typeof(EastFacingRover), 1, 1, 'F', Result = new int[] { 2, 1 })]
        [TestCase(typeof(EastFacingRover), 100, 100, 'F', Result = new int[] { 101, 100 })]
        [TestCase(typeof(EastFacingRover), 0, 0, 'B', Result = new int[] { -1, 0 })]
        [TestCase(typeof(EastFacingRover), 1, 1, 'B', Result = new int[] { 0, 1 })]
        [TestCase(typeof(EastFacingRover), 100, 100, 'B', Result = new int[] { 99, 100 })]
        public int[] EastFacingRoverMoveMethodSubtractsAndAddsToCoordinatesCorrectly(Type roverType, int startX, int startY, char movement)
        {
            IRover rover = (IRover)Activator.CreateInstance(roverType, startX, startY);
            rover = rover.Move(movement);
            return new int[] { rover.X, rover.Y };
        }

        [TestCase(typeof(EastFacingRover), 'L', typeof(NorthFacingRover))]
        [TestCase(typeof(EastFacingRover), 'R', typeof(SouthFacingRover))]
        public void EastFacingRoverReturnsCorrectDirectionalRoverAfterTurning(Type startType, char direction, Type endType)
        {
            IRover rover = (IRover)Activator.CreateInstance(startType, 0, 0);
            var rover2 = rover.Move(direction);
            Assert.IsInstanceOf(endType, rover2);
        }
    }
}
