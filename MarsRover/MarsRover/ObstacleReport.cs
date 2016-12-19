using System;

namespace MarsRover
{
    public class ObstacleReport
    {
        private static string message = "Obstacle encountered at point {0}, {1}. Movement terminated.";
        public ObstacleReport(Position obstaclePosition)
        {
            var obstacleCoordinates = obstaclePosition.Coordinates;
            Console.WriteLine(message, obstacleCoordinates[0], obstacleCoordinates[1]);
        }
    }
}