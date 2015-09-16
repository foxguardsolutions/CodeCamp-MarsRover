using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class MarsRover
    {
        public const int MapWidth = 100;
        public const int MapHeight = 100;
        public const int StartX = MapWidth / 2;
        public const int StartY = MapHeight / 2;

        private static Map mars;

        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                PrintUsage();
                return;
            }

            mars = new Map(MapWidth, MapHeight);
            mars.Obstacles = GenerateObstacles();
            Console.WriteLine("Generated {0} obstacles on mars!", mars.Obstacles.Count);
            Rover marsRover = new Rover(new NorthFacingRover(StartX, StartY), mars);
            foreach (char movement in args[0])
            {
                if (!marsRover.MoveRover(movement))
                {
                    return;
                }
            }

            Console.WriteLine("Rover moved to: ({0}, {1})", marsRover.X, marsRover.Y);
        }

        public static List<int[]> GenerateObstacles()
        {
            List<int[]> obstacles = new List<int[]>();
            Random generator = new Random();
            foreach (var number in Enumerable.Range(0, generator.Next(MapWidth * MapHeight)))
            {
                int x = generator.Next(MapWidth);
                int y = generator.Next(MapHeight);
                if (x != StartX && y != StartY)
                {
                    obstacles.Add(new int[] { x, y });
                }
            }

            return obstacles;
        }

        public static void PrintUsage()
        {
            Console.WriteLine("Usage: {0} <movementString>", AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
