namespace MarsRover
{
    public class FacingEast : IOrientation
    {
        public Position Translate(Position position)
        {
            var nextPosition = position.Clone();
            nextPosition.Coordinates[0]++;
            return nextPosition;
        }
    }
}
