using System;

namespace MarsRover
{
    using NUnit.Framework;

    [TestFixture]
    public class RoverTest
    {
        [TestCase("FFLFF", Grid.Direction.EAST, 5, 6, 7, 5)]
        [TestCase("FFFFFFFFFFFFFFFFFF", Grid.Direction.NORTH, 9, 5, 9, 7)]
        [TestCase("BBBRFF", Grid.Direction.SOUTH, 3, 1, 2, 8)]
        [TestCase("FLFFFFLFRFFRFFRFFRF", Grid.Direction.WEST, 2, 3, 1, 7)]
        public void TestMove(string movements, Grid.Direction direction, int startX, int startY, int finalX, int finalY)
        {
            Grid world = new Grid(10, 10);

            Rover rover = new Rover(startX, startY, direction);

            world.GridCellAt(3, 5).ContainsObstacle = true;
            world.GridCellAt(3, 6).ContainsObstacle = true;
            world.GridCellAt(1, 8).ContainsObstacle = true;
            world.GridCellAt(7, 4).ContainsObstacle = true;
            world.GridCellAt(6, 2).ContainsObstacle = true;

            rover.World = world;

            foreach (char movement in movements)
            {
                if (!rover.Move((Movement)movement))
                {
                    break;
                }
            }

            Console.WriteLine("Final Location: " + rover.CurrentLocation.X + " " + rover.CurrentLocation.Y);

            Assert.AreEqual(finalX, rover.CurrentLocation.X);
            Assert.AreEqual(finalY, rover.CurrentLocation.Y);
        }
    }
}
