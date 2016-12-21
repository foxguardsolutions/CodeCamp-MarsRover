using System;
using System.IO;

namespace MarsRover
{
    public class ObstacleReport
    {
        private static string message = "Obstacle encountered at point {0}, {1}. Movement terminated.";

        public ObstacleReport(Position obstaclePosition)
            : this(obstaclePosition, Console.Out)
        {
        }

        public ObstacleReport(Position obstaclePosition, TextWriter output)
        {
            var obstacleCoordinates = obstaclePosition.Coordinates;
            output.WriteLine(message, obstacleCoordinates[0], obstacleCoordinates[1]);
        }
    }
}