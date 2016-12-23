namespace MarsRover
{
    public class ObstacleReport
    {
        public ObstacleReport(Position position, IConsoleWriter output)
        {
            output.WriteLine($"Obstacle encountered at position ({position.GetCoordinates()}). Movement terminated.");
        }
    }
}
