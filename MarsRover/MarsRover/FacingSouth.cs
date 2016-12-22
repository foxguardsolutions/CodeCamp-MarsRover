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

        public void Rotate(Rover contextRover, bool isTurningCounterclockwise)
        {
            if (isTurningCounterclockwise)
            {
                contextRover.SetOrientation(new FacingEast());
            }
            else
            {
                contextRover.SetOrientation(new FacingWest());
            }
        }
    }
}
