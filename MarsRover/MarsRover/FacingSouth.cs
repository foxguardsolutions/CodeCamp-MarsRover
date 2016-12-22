namespace MarsRover
{
    public class FacingSouth : IOrientation
    {
        public Position Translate(Position position)
        {
            var nextPosition = position.Clone();
            nextPosition.Coordinates[1]--;
            return nextPosition;
        }
    }
}
