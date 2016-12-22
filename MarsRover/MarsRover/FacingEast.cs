namespace MarsRover
{
    public class FacingEast : IOrientation
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
                nextPosition.Coordinates[0]++;
            }
            else
            {
                nextPosition.Coordinates[0]--;
            }
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
