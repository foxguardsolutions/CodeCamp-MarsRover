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

        public void Rotate(Rover contextRover, bool isTurningCounterclockwise)
        {
            if (isTurningCounterclockwise)
            {
                contextRover.SetOrientation(new FacingNorth());
            }
            else
            {
                contextRover.SetOrientation(new FacingSouth());
            }
        }
    }
}
