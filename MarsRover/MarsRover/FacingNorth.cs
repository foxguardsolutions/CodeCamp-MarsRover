namespace MarsRover
{
    public class NorthFacing : IOrientation
    {
        public Position Translate(Position position)
        {
            var nextPosition = position.Clone();
            nextPosition.Coordinates[1]++;
            return nextPosition;
        }
    }
}