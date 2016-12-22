using System;

namespace MarsRover
{
    public class FacingWest : IOrientation
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
                nextPosition.DecrementCoordinate(0);
            }
            else
            {
                nextPosition.IncrementCoordinate(0);
            }
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
