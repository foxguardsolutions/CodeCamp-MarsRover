namespace MarsRover
{
    public class FacingSouth : IOrientation
    {
        public Position Translate(Position position, bool isMovingForward)
        {
            var nextPosition = position.Clone();
            AdjustCoordinates(nextPosition, isMovingForward);
            return nextPosition;
        }

        private void AdjustCoordinates(Position nextPosition, bool isMovingForward)
        {
            if (isMovingForward)
            {
                nextPosition.Coordinates[1]--;
            }
            else
            {
                nextPosition.Coordinates[1]++;
            }
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
