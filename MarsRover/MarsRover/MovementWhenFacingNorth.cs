namespace MarsRover
{
    public class MovementWhenFacingNorth : IMovementFrameOfReference
    {
        public Position MoveForward(Position lastPosition)
        {
            return lastPosition.IncrementCoordinate(1);
        }

        public Position MoveBackward(Position lastPosition)
        {
            return lastPosition.DecrementCoordinate(1);
        }

        public void RotateCounterclockwise(Rover contextRover)
        {
            contextRover.SetFrameOfReference(new MovementWhenFacingWest());
        }

        public void RotateClockwise(Rover contextRover)
        {
            contextRover.SetFrameOfReference(new MovementWhenFacingEast());
        }
    }
}