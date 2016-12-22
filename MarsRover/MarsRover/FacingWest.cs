namespace MarsRover
{
    public class FacingWest : IOrientation
    {
        public Position Translate(Position position)
        {
            var nextPosition = position.Clone();
            nextPosition.Coordinates[0]--;
            return nextPosition;
        }

        public void Rotate(Rover contextRover, bool isTurningCounterclockwise)
        {
            if (isTurningCounterclockwise)
            {
                contextRover.SetOrientation(new FacingSouth());
            }
            else
            {
                contextRover.SetOrientation(new FacingNorth());
            }
        }
    }
}
