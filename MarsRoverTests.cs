using NUnit.Framework;

namespace MarsRover
{
    [TestFixture]
    public class MarsRoverTests
    {
        public static int Main(string[] args)
        {
            return 0;
        }

        [Test]
        public void ConstructorSetsPointToZeroZeroPointingNorth()
        {
            MarsRover rover = new MarsRover();
            Assert.AreEqual(0, rover.X);
            Assert.AreEqual(0, rover.Y);
            Assert.AreEqual('N', rover.Direction);
        }

        [TestCase(1, 1, 'S')]
        [TestCase(2, 2, 'E')]
        public void ConstructorSetsRoverCoordinatesAndDirection(int x, int y, char direction)
        {
            MarsRover rover = new MarsRover(x, y, direction);
            Assert.AreEqual(x, rover.X);
            Assert.AreEqual(y, rover.Y);
            Assert.AreEqual(direction, rover.Direction);
        }

        [TestCase('N', 'W')]
        [TestCase('W', 'S')]
        [TestCase('S', 'E')]
        [TestCase('E', 'N')]
        public void LeftChangesRoverDirectionCounterClockwise(char direction, char expected)
        {
            MarsRover rover = new MarsRover(direction: direction);
            rover.Left();
            Assert.AreEqual(expected, rover.Direction);
        }

        [TestCase('N', 'E')]
        [TestCase('W', 'N')]
        [TestCase('S', 'W')]
        [TestCase('E', 'S')]
        public void RightChangesRoverDirectionClockwise(char direction, char expected)
        {
            MarsRover rover = new MarsRover(direction: direction);
            rover.Right();
            Assert.AreEqual(expected, rover.Direction);
        }

        [TestCase(1, 1, 'N', 1, 0)]
        [TestCase(2, 2, 'N', 2, 1)]
        [TestCase(1, 1, 'S', 1, 2)]
        [TestCase(2, 2, 'S', 2, 3)]
        [TestCase(1, 1, 'E', 2, 1)]
        [TestCase(2, 2, 'E', 3, 2)]
        [TestCase(1, 1, 'W', 0, 1)]
        [TestCase(2, 2, 'W', 1, 2)]
        public void ForwardAdvancesRoverOneSpaceInDirection(int startX, int startY, char direction, int expectedX, int expectedY)
        {
            MarsRover rover = new MarsRover(startX, startY, direction);
            rover.Forward();
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
        }

        [TestCase(1, 1, 'N', 1, 2)]
        [TestCase(2, 2, 'N', 2, 3)]
        [TestCase(1, 1, 'S', 1, 0)]
        [TestCase(2, 2, 'S', 2, 1)]
        [TestCase(1, 1, 'E', 0, 1)]
        [TestCase(2, 2, 'E', 1, 2)]
        [TestCase(1, 1, 'W', 2, 1)]
        [TestCase(2, 2, 'W', 3, 2)]
        public void BackwardRecedesRoverOneSpaceInDirection(int startX, int startY, char direction, int expectedX, int expectedY)
        {
            MarsRover rover = new MarsRover(startX, startY, direction);
            rover.Backward();
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
        }

        [TestCase(0, 0, 'N', 0, 9)]
        [TestCase(0, 9, 'S', 0, 0)]
        [TestCase(0, 0, 'W', 9, 0)]
        [TestCase(9, 0, 'E', 0, 0)]
        public void RoverWrapsAroundMapCoordinates(int startX, int startY, char direction, int expectedX, int expectedY)
        {
            MarsRover rover = new MarsRover(startX, startY, direction);
            rover.Forward();
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
        }

        [TestCase(0, 0, 'N', new char[] { 'f', 'l', 'f' }, 9, 9, 'W')]
        [TestCase(1, 2, 'E', new char[] { 'f', 'f', 'r', 'r', 'b' }, 4, 2, 'W')]
        public void MakeMovesAdvancesRoverAccordingToCharacterArray(int startX, int startY, char direction, char[] moves, int expectedX, int expectedY, char expectedDirection)
        {
            MarsRover rover = new MarsRover(startX, startY, direction);
            rover.MakeMoves(moves);
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
            Assert.AreEqual(expectedDirection, rover.Direction);
        }

        [TestCase(2, 4, 'E', new char[] { 'f', 'f', 'f' }, 3, 4, 'E')]
        public void RoverStopsMovingWhenAnObstacleIsEncountered(int startX, int startY, char direction, char[] moves, int expectedX, int expectedY, char expectedDirection)
        {
            MarsRover rover = new MarsRover(startX, startY, direction);
            rover.MakeMoves(moves);
            Assert.AreEqual(expectedX, rover.X);
            Assert.AreEqual(expectedY, rover.Y);
            Assert.AreEqual(expectedDirection, rover.Direction);
        }
    }
}
