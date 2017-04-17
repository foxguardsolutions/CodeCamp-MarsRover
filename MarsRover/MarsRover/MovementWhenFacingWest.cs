namespace MarsRover
{
    public class MovementWhenFacingWest : IMovementFrameOfReference
    {
        public Position MoveForward(Position lastPosition)
        {
            return lastPosition.DecrementCoordinate(0);
        }

        public Position MoveBackward(Position lastPosition)
        {
            return lastPosition.IncrementCoordinate(0);
        }

        public void RotateCounterclockwise(Rover contextRover)
        {
            contextRover.SetFrameOfReference(new MovementWhenFacingSouth());
        }

        public void RotateClockwise(Rover contextRover)
        {
            contextRover.SetFrameOfReference(new MovementWhenFacingNorth());
        }
    }
}
