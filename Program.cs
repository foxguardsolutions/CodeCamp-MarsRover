using System;

namespace MarsRover
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int xLoc = AskForXLocation();
            int yLoc = AskForYLocation();
            char direction = AskForDirection();
            string movements = AskForMovements();

            Rover rover = new Rover(xLoc, yLoc, direction);

            rover.World = CreateWorld();

            foreach (char movement in movements)
            {
                if (!rover.Move(movement))
                {
                    break;
                }
            }

            Console.WriteLine("Final Location: " + rover.CurrentLocation.X + " " + rover.CurrentLocation.Y);
        }

        private static int AskForXLocation()
        {
            Console.WriteLine("Enter your starting X Location:");

            int xLoc = int.Parse(Console.ReadLine());

            return xLoc;
        }

        private static int AskForYLocation()
        {
            Console.WriteLine("Enter your starting Y Location:");

            int yLoc = int.Parse(Console.ReadLine());

            return yLoc;
        }

        private static char AskForDirection()
        {
            Console.WriteLine("Enter your starting direction (N, E, S, W):");

            char direction = Convert.ToChar(Console.ReadLine());

            return direction;
        }

        private static string AskForMovements()
        {
            Console.WriteLine("Enter your movements (L, R, F, B):");

            string movements = Console.ReadLine();

            return movements;
        }

        private static Grid CreateWorld()
        {
            Grid world = new Grid(10, 10);

            world.GridCellAt(3, 5).ContainsObstacle = true;
            world.GridCellAt(3, 6).ContainsObstacle = true;
            world.GridCellAt(1, 8).ContainsObstacle = true;
            world.GridCellAt(7, 4).ContainsObstacle = true;
            world.GridCellAt(6, 2).ContainsObstacle = true;

            return world;
        }
    }
}
