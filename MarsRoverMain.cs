using System;

namespace MarsRover
{
    public class MarsRoverMain
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your starting X Location:");

                int xLoc = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter your starting Y Location:");

                int yLoc = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter your starting orientation (0, 90, 180, 270):");

                Grid.Direction orientation = (Grid.Direction)int.Parse(Console.ReadLine());

                Console.WriteLine("Enter your movements (L, R, F, B):");

                string movements = Console.ReadLine();

                Rover rover = new Rover(xLoc, yLoc, orientation);

                Grid world = new Grid(10, 10);

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
            }
        }
    }
}
